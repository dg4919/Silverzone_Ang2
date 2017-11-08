using Silverzone.Data.Interfaces;
using Silverzone.Entities;
using System.Linq;

namespace Silverzone.Data.Repositories
{
    public class MasterAcademicYearRepository:BaseRepository<MasterAcademicYear>,IMasterAcademicYearRepository
    {
        public MasterAcademicYearRepository(SilverzoneContext  dbcontext) : base(dbcontext) { }

        public MasterAcademicYear GetById(int  id)
        {
            return _dbset.Where(x => x.Id == id).SingleOrDefault();
        }

        public  MasterAcademicYear  GetByYear(string Year)
        {
            return FindBy(x => x.CurrentAcademicYear == Year).SingleOrDefault();
        }
    }
}
