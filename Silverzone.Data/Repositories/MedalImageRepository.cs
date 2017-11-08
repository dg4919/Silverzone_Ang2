using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class MedalImageRepository:BaseRepository<MedalImage>,IMedalImageRepository
    {
        public MedalImageRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public MedalImage GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }

        public  IEnumerable<MedalImage> GetByStatus(bool status)
        {
            return FindBy(x => x.Status == status).AsEnumerable();
        }
    }
}
