using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class BookBundleDetails : Entity<int>
    {
        public int BundleId { get; set; }

        [ForeignKey("BundleId")]
        public virtual BookBundle bookBundle { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book book { get; set; }
    }
}
