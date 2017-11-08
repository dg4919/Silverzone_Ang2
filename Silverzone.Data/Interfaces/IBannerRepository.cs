using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public interface IBannerRepository:IRepository<Banner>
    {
        Banner GetById(int id);
        IEnumerable<Banner> GetByStatus(bool status);
    }
}
