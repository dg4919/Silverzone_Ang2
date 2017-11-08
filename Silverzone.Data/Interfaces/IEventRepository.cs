using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public  interface IEventRepository:IRepository<Event>
    {
        Event GetByCode(string ecode);
        Event GetById(int id);
        Event GetByName(string ename);
        IEnumerable<Event> GetByStatus(bool status);

        bool is_eventExist(string eventName, string eventCode);
    }
}
