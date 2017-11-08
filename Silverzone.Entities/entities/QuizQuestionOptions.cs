using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class QuizQuestionOptions : Entity<int>
    {
        public string Option { get; set; }

        public int QuizId { get; set; }

        public string ImageUrl { get; set; }

        public bool isAnswer { get; set; }

        [ForeignKey("QuizId")]      // virtual must use to initialize this navigation prop values :)
        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}
