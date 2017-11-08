using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class BookDetail:Entity<int>
    {
        [MaxLength(300)]
        public string BookDescription { get; set; }

        //public int ContentId { get; set; }
        //public Content Content { get; set; }

        // use to create foreign key
        //public int BookId { get; set; }

        [ForeignKey("Id")]
        public virtual Book Book { get; set; }
   }
}
