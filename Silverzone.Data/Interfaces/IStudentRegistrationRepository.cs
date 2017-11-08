using Silverzone.Entities;
using System.Collections.Generic;

namespace Silverzone.Data.Interfaces
{
    public interface IStudentRegistrationRepository:IRepository<StudentRegistration>
    {
        StudentRegistration GetById(int id);
        IEnumerable<StudentRegistration> GetByEventCode(string ecode);
        IEnumerable<StudentRegistration> GetBySchoolCode(string schcode);
        IEnumerable<StudentRegistration> GetByRegSrlNo(int srno);
        IEnumerable<StudentRegistration> GetByEventCodeAndSchCode(string ecode, string schcode);
        IEnumerable<StudentRegistration> GetByExamDateOpted(int edate);

    }
}
