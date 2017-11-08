using Silverzone.Entities;
namespace Silverzone.Data
{
    public class classRepository : BaseRepository<Class>, IclassRepository
    {
        public classRepository(SilverzoneContext dbcontext) : base(dbcontext) { }        

    }
}
