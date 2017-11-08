using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class Category:AuditableEntity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        public int? CouponId { get; set; }

        [ForeignKey("CouponId")]             // virtual is must to get > all related (primary & foreign key based) data
        public virtual Coupon Coupons { get; set; }

        public bool is_Active { get; set; }        
        public virtual ICollection<Book> Books { get; set; }
    }
}
