using Silverzone.Entities;

namespace Silverzone.Data
{
    public class TeacherDetailRepository : BaseRepository<TeacherDetail>, ITeacherDetailRepository
    {
        public TeacherDetailRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        //public TeacherDetail GetById(int id)
        //{
        //    return FindBy(x => x.Id == id).FirstOrDefault();
        //}
    }
}
