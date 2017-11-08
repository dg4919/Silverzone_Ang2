using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data
{
    public class CourierRepository : BaseRepository<Courier>, ICourierRepository
    {
        public CourierRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public override IQueryable<Courier> GetAll()
        {
            return FindBy(x => x.is_Active == true);  // there will be always 1 record
        }
    }
}
