using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public interface IOlympiadListRepository:IRepository<OlympiadList>
    {
        OlympiadList GetById(int id);
       IEnumerable<OlympiadList> GetByStatus(bool status);
    }
}
