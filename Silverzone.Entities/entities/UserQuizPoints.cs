using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class UserQuizPoints : Entity<int>
    {
        public int UserId { get; set; }
        public User UserInfo { get; set; }

        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public QuizQuestion quiz { get; set; }

        public int Answerid { get; set; }

        public DateTime Submit_Date{ get; set; }

    }
}
