using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class BookDetailRepository:BaseRepository<BookDetail>,IBookDetailRepository
    {
        public BookDetailRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public BookDetail GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<BookDetail> GetByBookId(int id)
        {
            return _dbset.Where(x => x.Id == id).AsEnumerable();
        }
    

    }
}
