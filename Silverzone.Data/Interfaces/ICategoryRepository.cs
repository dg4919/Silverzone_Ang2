using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface ICategoryRepository :IRepository<Category>
    {
        Category GetById(int id);
        IEnumerable<Category> GetByNameAndStatus(string name, bool status);
        IEnumerable<Category> GetByStatus(bool status);

        ICollection<Category> GetByName(string Name);
        bool Iscategory_Exist(string Name, int Id);
    }
}
