using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public bool role_isActive(int id)
        {
            return _dbset.Any(x => x.Id == id && x.is_Active == true);
        }

        public Role GetByName(string Name)
        {
            return FindBy(x => x.Name.Equals(Name)).SingleOrDefault();
        }

    }
}
