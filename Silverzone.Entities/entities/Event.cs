using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class Event:Entity<int>
    {
        [Required, MaxLength(20)]
        public string EventCode { get; set; }

        [Required, MaxLength(20)]
        public string EventName { get; set; }

        public bool is_Active { get; set; }
    }
}
