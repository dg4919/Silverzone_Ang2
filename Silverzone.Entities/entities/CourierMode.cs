using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class CourierMode : AuditableEntity<int>
    {
        [Required]
        public string Courier_Mode { get; set; }

        [Required]
        public int CourierId { get; set; }
        public Courier Courier { get; set; }

        [Required]
        public bool is_Active { get; set; }        
    }
}
