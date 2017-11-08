using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class Courier : AuditableEntity<int>
    {
        [Required]
        public string Courier_name { get; set; }

        [Required]
        public string Courier_Link { get; set; }

        [Required]
        public bool is_Active { get; set; }

        public virtual IEnumerable<CourierMode> CourierMode { get; set; }
    }
}
