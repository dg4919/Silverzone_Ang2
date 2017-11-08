using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class OlympiadListRepository : BaseRepository<OlympiadList>, IOlympiadListRepository
    {
        public OlympiadListRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
        public OlympiadList GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<OlympiadList> GetByStatus(bool status)
        {
            return FindBy(x => x.Status == status).AsEnumerable();
        }
    }
}
