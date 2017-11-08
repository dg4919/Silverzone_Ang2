using System;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class Query:Entity<int>
    {
        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(200)]
        public string QueryDetail { get; set; }
        public int OldRef { get; set; }
        public DateTime QueryDate { get; set; }

        [MaxLength(20)]
        public string QueryStatus { get; set; }
        public DateTime CloseDate { get; set; }


        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
