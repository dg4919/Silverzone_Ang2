using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class BundleRepository:BaseRepository<BookBundle>,IBundleRepository
    {
        public BundleRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
        public BookBundle GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }

        //public BookBundle GetByBookId(int id)
        //{
        //    return FindBy(x => x.BookId == id).FirstOrDefault();
        //}
    }
}
