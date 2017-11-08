using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class QuickLinkRepository:BaseRepository<QuickLink>,IQuickLinkRepository
    {
        public QuickLinkRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
        public QuickLink  GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<QuickLink> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.Status == status).AsEnumerable();
        }
    }
}
