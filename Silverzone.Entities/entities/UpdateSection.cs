using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class UpdateSection:Entity<int>
    {
        [MaxLength(20)]
        public string Heading { get; set; }

        [MaxLength(150)]
        public string UpdateLine { get; set; }

        [MaxLength(30)]
        public string LinkText { get; set; }

        [MaxLength(30)]
        public string LinkUrl { get; set; }
        public bool Status { get; set; }
    }
}
