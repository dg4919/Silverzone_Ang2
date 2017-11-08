using Silverzone.Entities;

namespace Silverzone.Data.Interfaces
{
    public interface IMasterAcademicYearRepository:IRepository<MasterAcademicYear>
    {
        MasterAcademicYear GetById(int id);
        MasterAcademicYear GetByYear(string year);
    }
}
