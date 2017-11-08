namespace Silverzone.Entities
{
    public class OrderDetail:Entity<int>
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }

        public int? BookId { get; set; }
        public virtual Book Book { get; set; }      // Book + Id = BookId is FK 

        public int? BundleId { get; set; }
        public virtual BookBundle Bundle { get; set; }

        public decimal UnitPrice { get; set; }

        // book is a type of bundle or book
        public bookType bookType { get;  set; }
    }
}
