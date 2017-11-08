using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class Olympiads:Entity<int>
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Image Required")]
        public string ImageName { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Link Required")]
        public string Link { get; set; }
        public bool Status { get; set; }
    }
}
