using System;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class Enquiry:Entity<int>
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string EmailId { get; set; }

        [MaxLength(12)]
        public string Mobile { get; set; }

        [MaxLength(30)]
        public string Subject { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }
        public DateTime QueryDate { get; set; }
    }
}
