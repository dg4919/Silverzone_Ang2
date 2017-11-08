using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class BookContent:Entity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }
        public bool Status { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
