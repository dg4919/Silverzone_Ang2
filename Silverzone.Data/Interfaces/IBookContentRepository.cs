using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IBookContentRepository : IRepository<BookContent>
    {
        BookContent GetById(int id);
        BookContent GetByName(string name);
        IEnumerable<BookContent> GetByStatus(bool status);
    }
}
