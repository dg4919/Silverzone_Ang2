using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data
{
    public interface ICourierModeRepository : IRepository<CourierMode>
    {
        IQueryable<CourierMode> GetByCourierId(int CourierId);
    }
}
