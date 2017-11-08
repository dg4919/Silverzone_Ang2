using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IclassSubjectRepository : IRepository<classSubject>
    {
       IEnumerable<classSubject> Get_subjects_ByClassId(int classId);
    }
}
