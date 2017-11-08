using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data
{
    public class ProfileRepository:BaseRepository<Profile>,IProfileRepository
    {
        public ProfileRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Profile GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Profile> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.is_Active == status).AsEnumerable();
        }

        public bool isExist(string profileName)
        {
            return _dbset.Any(x => x.ProfileName.Equals(profileName));
        }

    }
}
