using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IBookDetailRepository:IRepository<BookDetail>
    {
        BookDetail GetById(int id);
        IEnumerable<BookDetail> GetByBookId(int id);
    }
}
