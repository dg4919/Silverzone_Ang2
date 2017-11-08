using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
using System.Data.Entity;

namespace Silverzone.Data
{
    public class BookRepository:BaseRepository<Book>,IBookRepository
    {
        public BookRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        //***********************  Book Filter  *************************

        public Book GetById(int id)
        {
            return FindBy(x => x.Id == id).SingleOrDefault();
        }
        public Book GetByTitle(string title)
        {
            return FindBy(x => x.Title == title).FirstOrDefault();
        }
        public Book GetByISBN(string isbn)
        {
            return FindBy(x => x.ISBN == isbn).FirstOrDefault();
        }

        public IEnumerable<Book> GetByAuthor(string authorName)
        {
            return _dbset.Where(x => x.Publisher == authorName).AsEnumerable();
        }    

        public Book GetByEdition(string edition)
       {
           return FindBy(x => x.Edition == edition).FirstOrDefault();
       }
        public IEnumerable<Book> GetByWeight(decimal weight)
        {
            return _dbset.Where(x => x.Weight == weight).AsEnumerable();
        }
        public IEnumerable<Book> GetByPrice(decimal price)
        {
            return _dbset.Where(x => x.Price == price).AsEnumerable();
        }
        public IEnumerable<Book> GetByPriceRange(decimal startprice, decimal endprice)
        {
            return _dbset.Where(x => x.Price >= startprice && x.Price <= endprice).AsEnumerable();
        }
        public IEnumerable<Book> GetByCategory(int categoryId)
        {
            return _dbset.Where(x => x.CategoryId == categoryId).AsEnumerable();
        }

        public Book get_books_byId(int bookId)
        {
            // find use to pass only PK value
            var book = _dbset.Find(bookId);

            return book;
        }
       
        // ***************  Used for filteration Records  **********************

        public IQueryable<Book> GetAllBooks()
        {
            return _dbset.Include(x => x.Category);
        }

        // bcoz where return IQueryable type > then after we can convert it into IEnumerable
        // books is the filtered records 
        public IEnumerable<Book> FilterByClassAndSubject(int classId, int subjectid, IQueryable<Book> books)
        {
            return books.Where(x => x.ClassId == classId && x.Id == subjectid);
        }

        public IEnumerable<Book> FilterByClassSubjectAndCategory(int classId, int subjectid, IEnumerable<int> categoriesId, IQueryable<Book> books)
        {
            return books.Where(x => x.ClassId == classId && x.Id == subjectid && categoriesId.Contains(x.CategoryId));
        }

        public IQueryable<Book> FilterByClassId(int? classId, IQueryable<Book> books)
        {
          return books.Where(x => x.ClassId == classId.Value);
        }

        public IQueryable<Book> FilterBySubjectId(int? subjectId, IQueryable<Book> books)
        {
            return books.Where(x => x.SubjectId == subjectId.Value);
        }

        public IQueryable<Book> FilterBycategoriesId(IEnumerable<int> categoriesId, IQueryable<Book> books)
        {
            return books.Where(x => categoriesId.Contains(x.CategoryId));
        }

        public List<string> upload_book_Image_toTemp(string tempPath)
        {
            return ClassUtility.upload_Images_toTemp(tempPath);
        }

        public bool check_book(int classId, int subjectId, int bookCategoryId)
        {
            return _dbset.Any(x => x.ClassId == classId
                                && x.SubjectId == subjectId
                                && x.CategoryId == bookCategoryId
                              );
        }

        public IQueryable<Book> GetByStatus(bool status)
        {
            return FindBy(x => x.is_Active == status
                            && x.Subject.Status == true         // only fetch active records
                            && x.Category.is_Active == true);
        }


    }
}
