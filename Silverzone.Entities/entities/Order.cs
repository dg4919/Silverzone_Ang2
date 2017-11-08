using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public partial class Order:Entity<int>
    {
        public string OrderNumber { get; set; }

        public decimal Total_Shipping_Amount { get; set; }
        public decimal Total_Shipping_Charges { get; set; }

        public System.DateTime OrderDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; }

        public orderType Payment_ModeType { get; set; }

        // bcoz these proprety r value type > so can handle 
        public bool? Payment_Status { get; set; }  // now can handle 'get/set' nullable value
        public orderStatusType? Order_Deliver_StatusType { get; set; }      // can hold null value when order will create then value of this type will be not pass
        public orderSourceType? orderSourceType { get; set; }

        public int Shipping_addressId { get; set; }
        [ForeignKey("Shipping_addressId")]
        public virtual UserShippingAddress UserShippingAddress { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int? Quiz_Points_Deduction { get; set; }

    }


}
