using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class BundleDetailRepository : BaseRepository<BookBundleDetails>, IBundleDetailRepository
    {
        public BundleDetailRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public BookBundleDetails GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
