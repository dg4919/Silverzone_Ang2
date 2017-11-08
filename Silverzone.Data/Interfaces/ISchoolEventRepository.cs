using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data.Interfaces
{
    public interface ISchoolEventRepository:IRepository<SchoolEvent>
    {
        SchoolEvent GetById(int id);
        IEnumerable<SchoolEvent> GetBySchCode(string SchCode);
        SchoolEvent GetByYear(string year);
    }
}
