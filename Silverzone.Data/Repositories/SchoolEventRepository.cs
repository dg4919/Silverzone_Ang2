using Silverzone.Data.Interfaces;
using Silverzone.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Silverzone.Data.Repositories
{
    public class SchoolEventRepository:BaseRepository<SchoolEvent>,ISchoolEventRepository
    {
        public SchoolEventRepository(SilverzoneContext dbcontext):base(dbcontext){}
        public SchoolEvent GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<SchoolEvent>  GetBySchCode(string schcode)
        {
            return _dbset.Where(x => x.SchCode == schcode).AsEnumerable();
        }
        public SchoolEvent GetByYear(string year)
        {
            return FindBy(x => x.EventYear == year).FirstOrDefault();
        }
    }
}
