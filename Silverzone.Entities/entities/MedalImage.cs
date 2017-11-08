using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class MedalImage:Entity<int>
    {
        [MaxLength(50)]
        public string ImageName { get; set; }
        public bool Status { get; set; }
    }
}
