using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;

namespace Silverzone.Data
{
    public interface IBookRepository:IRepository<Book>
    {
        Book GetById(int id);
        Book GetByTitle(string title);
        Book GetByISBN(string isbn);
        IEnumerable<Book> GetByAuthor(string authorName);
        //IEnumerable<Book> GetByClassAndSubject(string stdclass,int subjectid);
        Book GetByEdition(string edition);
        IEnumerable<Book> GetByWeight(decimal weight);
        IEnumerable<Book> GetByPrice(decimal price);
        IEnumerable<Book> GetByPriceRange(decimal startprice, decimal endprice);
        IEnumerable<Book> GetByCategory(int categoryId);
        Book get_books_byId(int bookId);

        IQueryable<Book> FilterByClassId(int? classId, IQueryable<Book> books);
        IQueryable<Book> FilterBySubjectId(int? subjectId, IQueryable<Book> books);
        IQueryable<Book> FilterBycategoriesId(IEnumerable<int> categoriesId, IQueryable<Book> books);

        List<string> upload_book_Image_toTemp(string tempPath);
        bool check_book(int classId, int subjectId, int bookCategoryId);
        IQueryable<Book> GetByStatus(bool status);

    }
}
