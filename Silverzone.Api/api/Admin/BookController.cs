using Silverzone.Data;
using System.Linq;
using Silverzone.Api.ViewModel.Admin;
using System.Web.Http;
using System;
using Silverzone.Entities;

namespace Silverzone.Api.api.Admin         // make sure end with versioning no.
{
    public class BookController : ApiController
    {
        IBookRepository bookRepository;     // private fields
        IBookDetailRepository bookDetailRepository;
        IBookContentRepository bookContentRepository;
        IBundleRepository bundleRepository;
        IBundleDetailRepository bundleDetailRepository;

        [HttpPost]
        public IHttpActionResult upload_bookImage()
        {
            var url = image_urlResolver.bookImage_main;
            var save_Imagespath = bookRepository.upload_book_Image_toTemp(url);

            return Ok(new { result = save_Imagespath });
        }

        [HttpPost]
        public IHttpActionResult create_book(bookViewModel model)
        {
            // return new insterted record Identity value
            int bookid = bookRepository.Create(bookInfo.Parse(model.bookInfo)).Id;

            bookDetailRepository.Create(new Entities.BookDetail()
            {
                Id = bookid,
                BookDescription = model.bookDetail.bookDescription
            });

            foreach (var bookContent in model.bookContent)
            {
                bookContentRepository.Create(new Entities.BookContent()
                {
                    Name = bookContent.Name,
                    Description = bookContent.Description,
                    BookId = bookid,
                    Status = true
                }, false);      // bulk insert so not saving data, just add
            }

            bookContentRepository.Save();       // save changes

            return Ok(new { result = "success" });
        }

        public IHttpActionResult update_book(bookViewModel model)
        {
            // return new insterted record Identity value
            var entity = bookRepository.FindById(model.bookInfo.bookId);

            if (entity != null)
            {
                // now transaction start > we can change in any table & commit OR rollback records
                using (var transaction = bookRepository.BeginTransaction())
                {
                    try
                    {
                        bookRepository.Update(bookInfo.Parse(entity, model.bookInfo));

                        // entity.BookDetails contain model to update & model.bookDetail is new updatable model
                        bookDetailRepository.Update(bookDetail.Parse(model.bookDetail, entity.BookDetails));

                        // delete all existed multiple record
                        bookContentRepository.DeleteWhere(entity.BookContents);
                        foreach (var bookContent in model.bookContent)
                        {
                            bookContentRepository.Create(new Entities.BookContent()
                            {
                                Name = bookContent.Name,
                                Description = bookContent.Description,
                                BookId = entity.Id,         // contain book id
                                Status = true
                            }, false);      // bulk insert so not saving data, just add
                        }

                        bookContentRepository.Save();       // save changes
                        transaction.Commit();       // it must be there if want to save record :)

                        return Ok(new { result = "success" });
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Ok(new { result = "error" });
                    }
                }
            }

            return Ok(new { result = "notfound" });
        }

        public IHttpActionResult is_bookExist(book_existViewModel model)
        {
            // reverse conditon
            if (bookRepository.check_book(model.classId, model.subjectId, model.bookCategoryId))
            {
                var data = bookRepository.FindBy(x =>
                                    x.ClassId == model.classId
                                 && x.SubjectId == model.subjectId
                                 && x.CategoryId == model.bookCategoryId
                               ).SingleOrDefault();     // we got only 1 record & SingleOrDefault cant apply with bookRepository class directly

                return Ok(new
                {
                    result = "exist",
                    entity = bookViewModel.Parse(data)
                });
            }
            else
            {
                return Ok(new { result = "success" });
            }
        }

        [HttpPost]
        public IHttpActionResult get_bookList(book_serchViewModel model)
        {
            var books = bookRepository.GetByStatus(true);

            if (model.classId.HasValue)
                books = bookRepository.FilterByClassId(model.classId.Value, books);           // we must get a clssId to filter

            // we dont need to Filter with ClassId & SubjectId > bcoz previous book record contain data with a particular classId
            // then we r again filtering from that record with subjectId
            if (model.subjectId.HasValue)
                books = bookRepository.FilterBySubjectId(model.subjectId.Value, books);

            if (model.bookCategoryId.Count != 0)       // count property is have icollection Type
                books = bookRepository.FilterBycategoriesId(model.bookCategoryId, books);


            var data = books.Select(x => new
            {      // selected few property whuich we required !
                bookId = x.Id,
                bookTitle = x.Title,
                bookImage = x.BookImage,
                bookPrice = x.Price,
                className = x.Class.className,
                subject = x.Subject.Name,
                bookCategory = x.Category.Name,
                inStock = x.in_Stock,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                UpdationDate = x.UpdationDate
            });

            return Ok(new { result = data });
        }

        [HttpGet]
        public IHttpActionResult get_book_byId(int Id)
        {
            var model = bookRepository.FindById(Id);
            return Ok(new { result = bookViewModel.Parse(model) });
        }

        [HttpGet]
        public IHttpActionResult delete_book(int Id)
        {
            var model = bookRepository.FindById(Id);
            model.is_Active = false;
            bookRepository.Update(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult setBook_outOfstock(int Id, bool status)
        {
            var model = bookRepository.FindById(Id);
            model.in_Stock = status;
            bookRepository.Update(model);

            return Ok();
        }

        // *********************  Book Bundles/Discount Bundles  *********************

        [HttpPost]
        public IHttpActionResult create_bundle(bundleViewModel model)
        {
            // return new insterted record Identity value
            int bundleId = bundleRepository.Create(bundleViewModel.Parse(model)).Id;

            foreach (var id in model.booksId)
            {
                bundleDetailRepository.Create(new BookBundleDetails()
                {
                    BundleId = bundleId,
                    BookId = id
                }, false);      // bulk insert so not saving data, just add
            }

            bundleDetailRepository.Save();       // save changes

            return Ok(new { result = "success" });
        }

        [HttpPut]
        public IHttpActionResult update_bundle(bundleViewModel model)
        {
            // return new insterted record Identity value
            var bundle = bundleRepository.GetById(model.BundleId);

            if (bundle == null)
                return Ok(new { result = "notfound" });

            // start transaction
            using (var transaction = bundleRepository.BeginTransaction())
            {
                try
                {
                    // update bundle
                    bundleRepository.Update(bundleViewModel.Parse(model, bundle));

                    // delete all existed multiple record
                    bundleDetailRepository.DeleteWhere(bundle.bundle_details);

                    // add new record
                    foreach (var id in model.booksId)
                    {
                        bundleDetailRepository.Create(new BookBundleDetails()
                        {
                            BundleId = model.BundleId,
                            BookId = id
                        }, false);      // bulk insert so not saving data, just add
                    }

                    bundleDetailRepository.Save();       // save changes

                    transaction.Commit();       // it must be there if want to save record :)
                    return Ok(new { result = "success" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Ok(new { result = "error" });
                }
            }
        }

        [HttpGet]
        public IHttpActionResult get_bundleList()
        {
            // return new insterted record Identity value
            var bundles = bundleRepository.GetAll()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                    x.bundle_totalPrice,
                    x.books_totalPrice,
                    x.is_Active
                    //x.CreatedBy,
                    //x.UpdatedBy,
                    //x.UpdationDate
                });

            return Ok(new { result = bundles });
        }


        [HttpGet]
        public IHttpActionResult get_bundlebyId(int bundleId)
        {            
            var booksId = bundleDetailRepository.FindBy(x => x.BundleId == bundleId).Select(x => x.BookId);

           var books = bookRepository.FindBy(x => booksId.Contains(x.Id));

            var bundle = new
            {
                bundleInfo = bundleViewModel.Parse(bundleRepository.GetById(bundleId)),
                bookInfo = books.Select(model => new
                {
                    bookId = model.Id,
                    bookTitle = model.Title,
                    bookImage = model.BookImage,
                    bookPrice = model.Price,
                    className = model.Class.className,
                    subject = model.Subject.Name,
                    bookCategory = model.Category.Name
                })
            };

            return Ok(new { result = bundle });
        }


        [HttpDelete]
        public IHttpActionResult delete_bundle(int bundleId, bool status)
        {
            var bundleInfo = bundleRepository.GetById(bundleId);

            bundleInfo.is_Active = status;
            bundleRepository.Update(bundleInfo);

            return Ok(new { result = "success" });
        }


        public BookController(
            IBookRepository _bookRepository,
            IBookDetailRepository _bookDetailRepository,
            IBookContentRepository _bookContentRepository,
            IBundleRepository _bundleRepository,
            IBundleDetailRepository _bundleDetailRepository)
        {
            bookRepository = _bookRepository;
            bookDetailRepository = _bookDetailRepository;
            bookContentRepository = _bookContentRepository;
            bundleRepository = _bundleRepository;
            bundleDetailRepository = _bundleDetailRepository;
        }


    }
}
