using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class QuizQuestion : AuditableEntity<int>
    {
        public string Question { get; set; }

        public int? AnswerId { get; set; }

        public string ImageUrl { get; set; }

        public int Points { get; set; }

        [DataType(DataType.Date)]
        public DateTime Active_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? End_Date { get; set; }

        public quizType QuizType { get; set; }

        public string Prize { get; set; }
        public string PrizeImage { get; set; }

        public bool is_Active { get; set; }

        public virtual ICollection<QuizQuestionOptions> QuizOptions { get; set; }
    }
}
