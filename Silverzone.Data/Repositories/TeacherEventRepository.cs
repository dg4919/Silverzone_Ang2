using Silverzone.Entities;

namespace Silverzone.Data
{
    public class TeacherEventRepository : BaseRepository<TeacherEvent>, ITeacherEventRepository
    {
        public TeacherEventRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
    
    }
}
