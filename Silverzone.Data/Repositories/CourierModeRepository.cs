using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data
{
    public class CourierModeRepository : BaseRepository<CourierMode>, ICourierModeRepository
    {
        public CourierModeRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public IQueryable<CourierMode> GetByCourierId(int CourierId)
        {
            return FindBy(x => x.CourierId == CourierId && x.is_Active == true);  // there will be always 1 record
        }
    }
}
