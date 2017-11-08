using Silverzone.Data.Interfaces;
using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data.Repositories
{
    public class EventCodeImagePathRepository : BaseRepository<EventCodeImagePath>, IEventCodeImagePathRepository
    {
        public EventCodeImagePathRepository(SilverzoneContext dbcontext) : base(dbcontext)
        {
        }

        public EventCodeImagePath GeByEventCode(int id)
        {
            return FindBy(x => x.EventId == id).SingleOrDefault();
        }
    }
}
