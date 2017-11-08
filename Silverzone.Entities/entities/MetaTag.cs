using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
   public  class MetaTag:Entity<int>
    {
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Link { get; set;}

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string Keyword { get; set; }
        public bool Status { get; set; }
    }
}
