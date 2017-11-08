using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Api.ViewModel.Admin
{
    public class bookViewModel
    {
        public ICollection<bookContent> bookContent { get; set; }
        public bookInfo bookInfo { get; set; }
        public bookDetail bookDetail { get; set; }

        public static bookViewModel Parse(Book model)
        {
            return new bookViewModel()
            {
                bookInfo = bookInfo.Parse(model),
                bookDetail = bookDetail.Parse(model.BookDetails),
                bookContent = Admin.bookContent.Parse(model.BookContents),
            };
        }
    }

    public class bookInfo
    {
        public int bookId { get; set; }
        public int classId { get; set; }
        public int subjectId { get; set; }
        public int bookCategoryId { get; set; }
        public string bookTitle { get; set; }
        public string bookImage { get; set; }
        public string bookISBN { get; set; }
        public string publisher { get; set; }
        public int bookPage { get; set; }
        public decimal bookWheight { get; set; }
        public decimal bookPrice { get; set; }

        public static bookInfo Parse(Book model)
        {
            return new bookInfo()
            {
                bookId = model.Id,
                bookTitle = model.Title,
                bookImage = model.BookImage,
                bookISBN = model.ISBN,
                bookPrice = model.Price,
                publisher = model.Publisher,
                bookPage = model.Pages,
                bookWheight = model.Weight,
                classId = model.ClassId,
                subjectId = model.SubjectId,
                bookCategoryId = model.CategoryId
            };
        }

        public static Book Parse(bookInfo model)
        {
            return new Book()
            {
                Title = model.bookTitle,
                BookImage = model.bookImage,
                ISBN = model.bookISBN,
                Price = model.bookPrice,
                Publisher = model.publisher,
                Pages = model.bookPage,
                Weight = model.bookWheight,
                ClassId = model.classId,
                SubjectId = model.subjectId,
                CategoryId = model.bookCategoryId,
                is_Active = true,
                in_Stock = true
            };
        }

        // for update model
        public static Book Parse(Book model, bookInfo newModel)
        {
            model.Title = newModel.bookTitle;
            model.BookImage = newModel.bookImage;
            model.ISBN = newModel.bookISBN;
            model.Price = newModel.bookPrice;
            model.Publisher = newModel.publisher;
            model.Pages = newModel.bookPage;
            model.Weight = newModel.bookWheight;
            model.ClassId = newModel.classId;
            model.SubjectId = newModel.subjectId;
            model.CategoryId = newModel.bookCategoryId;

            return model;
        }

    }

    public class bookDetail
    {
        public string bookDescription { get; set; }

        public static bookDetail Parse(BookDetail model)
        {
            return new bookDetail()
            {
                bookDescription = model.BookDescription
            };
        }

        // to update model
        public static BookDetail Parse(bookDetail newModel, BookDetail entity)
        {
            entity.BookDescription = newModel.bookDescription;
            return entity;
        }
    }

    public class bookContent
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static ICollection<bookContent> Parse(ICollection<BookContent> model)
        {
            return model.Select(x => new bookContent()
            {
                Name = x.Name,
                Description = x.Description
            }).ToList();            // to convert ienumerable to collection
        }

    }


    public class book_existViewModel
    {
        public int classId { get; set; }
        public int subjectId { get; set; }
        public int bookCategoryId { get; set; }
    }

    public class book_serchViewModel
    {
        public int? classId { get; set; }
        public int? subjectId { get; set; }
        public ICollection<int> bookCategoryId { get; set; }
    }

    public class bundleViewModel
    {
        public int BundleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal newPrice { get; set; }
        public decimal totalPrice { get; set; }

        public ICollection<int> booksId { get; set; }

        public static BookBundle Parse(bundleViewModel model)
        {
            return new BookBundle()
            {
                Name = model.Name,
                Description = model.Description,
                bundle_totalPrice = model.newPrice,
                books_totalPrice = model.totalPrice,
                is_Active = true
            };
        }

        public static bundleViewModel Parse(BookBundle model)
        {
            return new bundleViewModel()
            {
                BundleId = model.Id,
                Name = model.Name,
                Description = model.Description,
                newPrice = model.bundle_totalPrice,
                totalPrice = model.books_totalPrice,
            };
        }

        public static BookBundle Parse(bundleViewModel model, BookBundle myBundle)
        {
            myBundle.Name = model.Name;
            myBundle.Description = model.Description;
            myBundle.bundle_totalPrice = model.newPrice;
            myBundle.books_totalPrice = model.totalPrice;

            return myBundle;
        }


    }

}