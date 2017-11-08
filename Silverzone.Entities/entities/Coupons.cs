using System;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class Coupon : AuditableEntity<int>
    {
        [Required]
        public string Coupon_name { get; set; }

        [StringLength(140, MinimumLength = 1), Required]
        public string Description { get; set; }

        [Required]
        public int Coupon_amount { get; set; }

        [Required]
        public CouponType DiscountType { get; set; }

        [Required]
        public DateTime Start_time { get; set; }

        [Required]
        public DateTime End_time { get; set; }

        [Required]
        public bool is_Active { get; set; }
        public bool is_Deleted { get; set; }
    }
}
