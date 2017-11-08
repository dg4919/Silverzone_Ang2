using Silverzone.Entities;

namespace Silverzone.Data
{
    public class UserQuizPointsRepository : BaseRepository<UserQuizPoints>, IUserQuizPointsRepository
    {
        public UserQuizPointsRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
       
    }
}
