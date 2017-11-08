using Silverzone.Entities;
using System.Collections.Generic;


namespace Silverzone.Data
{
    public interface IMedalImageRepository:IRepository<MedalImage>
    {
        MedalImage GetById(int id);
        IEnumerable<MedalImage> GetByStatus(bool status);
    }
}
