using Silverzone.Entities;

namespace Silverzone.Data
{
    public class QuizQuestionOptionsRepository : BaseRepository<QuizQuestionOptions>, IQuizQuestionOptionsRepository
    {
        public QuizQuestionOptionsRepository(SilverzoneContext dbcontext) : base(dbcontext) { }
      
    }
}
