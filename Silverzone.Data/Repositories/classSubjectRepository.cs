using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class classSubjectRepository : BaseRepository<classSubject>, IclassSubjectRepository
    {
        public classSubjectRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public IEnumerable<classSubject> Get_subjects_ByClassId(int classId)
        {
            return FindBy(x => x.ClassId == classId);
        }
       

    }
}
