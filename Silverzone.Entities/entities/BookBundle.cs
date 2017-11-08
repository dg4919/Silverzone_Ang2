using System.Collections.Generic;

namespace Silverzone.Entities
{
    public class BookBundle : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal bundle_totalPrice { get; set; }
        public decimal books_totalPrice { get; set; }

        public bool is_Active { get; set; }

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public virtual ICollection<BookBundleDetails> bundle_details { get; set; }
    }
}
