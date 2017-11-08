using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IRoleRepository:IRepository<Role>
    {
        bool role_isActive(int id);

        //Role GetById(int id);
        Role GetByName(string Name);
    }
}
