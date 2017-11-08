using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Category GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        // ICollection have Count property > but IEnumerable has not
        public ICollection<Category> GetByName(string Name)
        {
            //return FindBy(x => x.Name == Name);            // match exact wrd
            //return FindBy(x => x.Name.Contains(Name));    // use as like by in SQL

            // trim use to remove extra space + match with lower case
            return FindBy(x => x.Name.ToLower().Trim() == Name.ToLower().Trim()).ToList();    // use as like by in SQL
        }

        public IEnumerable<Category> GetByNameAndStatus(string name,bool status)
        {
            // Extension methods of IQueryable<T> like > count, Add method will be show only in repostory > not in API
            return FindBy(x => x.Name.Contains(name) && x.is_Active == status).AsEnumerable();
        }

        public IEnumerable<Category> GetByStatus(bool status)
        {
            return _dbset.Where(x => x.is_Active == status).AsEnumerable();
        }
        
        public bool Iscategory_Exist(string Name, int Id)
        {
            return _dbset.Any(x => x.Name.ToLower().Trim() == Name.ToLower().Trim() && x.Id != Id);
        }

    }
}
