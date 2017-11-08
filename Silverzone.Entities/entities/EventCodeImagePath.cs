using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class EventCodeImagePath:Entity<int>
    {
        public int EventId { get; set; }
        [MaxLength(50)]
        public string EventImagePath { get; set; }
    }
}
