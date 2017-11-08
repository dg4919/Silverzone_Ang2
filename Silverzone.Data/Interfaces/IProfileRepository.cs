using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data
{
    public interface IProfileRepository:IRepository<Profile>
    {
        Profile GetById(int id);
        IEnumerable<Profile> GetByStatus(bool status);
        bool isExist(string profileName);
    }
}
