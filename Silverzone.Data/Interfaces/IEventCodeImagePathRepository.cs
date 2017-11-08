using Silverzone.Entities;

namespace Silverzone.Data.Interfaces
{
    public  interface IEventCodeImagePathRepository:IRepository<EventCodeImagePath>
    {
        EventCodeImagePath GeByEventCode(int eid);
    }
}
