using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class QuickLink:Entity<int>
    {
        [MaxLength(50)]
        [Required(ErrorMessage="Title Required")]
        public string Title { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Url Required")]
        public string Url { get; set; }
        public bool Status { get; set; }
    }
}
