using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public  class SchoolEvent:Entity<int>
    {
        [Required]
        public string SchCode { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public string EventYear { get; set; }
    }
}
