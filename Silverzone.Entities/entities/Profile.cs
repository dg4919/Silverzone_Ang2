using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class Profile:Entity<int>
    {
        [Required, MaxLength(50)]
        public string ProfileName { get; set; }

        public bool is_Active { get; set; }
    }
}
