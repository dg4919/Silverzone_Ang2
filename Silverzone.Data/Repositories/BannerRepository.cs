using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class BannerRepository:BaseRepository<Banner>,IBannerRepository
    {
        public BannerRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Banner GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<Banner> GetByStatus(bool stat)
        {
            return _dbset.Where(x => x.Status == stat).AsEnumerable();
        }
    }
}
