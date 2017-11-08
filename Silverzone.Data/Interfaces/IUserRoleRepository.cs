using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IUserRoleRepository:IRepository<UserRole>
    {
        //UserRole GetById(int id);
        //IEnumerable<UserRole> GetByUserId { get; set; }
        //IEnumerable<UserRole> GetByRoleId { get; set; }
        UserRole getByUserId(int userId);
    }
}
