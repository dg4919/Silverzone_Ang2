using System;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class FeedBack:Entity<int>
    {
        public int UserId { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string EmailId { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Class { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(50)]
        public string Message { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}
