using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

       public UserRole getByUserId(int userId)
        {
            return FindBy(x => x.UserId == userId).SingleOrDefault();
        }
    }
}
