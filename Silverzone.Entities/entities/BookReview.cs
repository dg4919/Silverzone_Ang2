using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class BookReview:AuditableEntity<int>
    {
        [MaxLength(300)]
        public string Review { get; set; }
        public string Rating { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
     
    }
}
