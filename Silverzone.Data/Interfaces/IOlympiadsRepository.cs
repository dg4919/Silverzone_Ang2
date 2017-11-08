using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public interface IOlympiadsRepository:IRepository<Olympiads>
    {
        Olympiads GetById(int id);
        IEnumerable<Olympiads> GetByStatus(bool status);
    }
}
