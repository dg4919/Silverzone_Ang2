using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class EventRepository:BaseRepository<Event>,IEventRepository
    {
        public EventRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
        public Event GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public Event GetByCode(string code)
        {
            return FindBy(x => x.EventCode == code).FirstOrDefault();
        }
        public Event GetByName(string name)
        {
            return FindBy(x => x.EventName==name).FirstOrDefault();
        }

        public IEnumerable<Event> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.is_Active == status).AsEnumerable();
        }

        public bool is_eventExist(string eventName, string eventCode)
        {
            return _dbset.Any(x => x.EventCode.Equals(eventCode)
                                && x.EventName.Equals(eventName)
                                );
        }

    }
}
