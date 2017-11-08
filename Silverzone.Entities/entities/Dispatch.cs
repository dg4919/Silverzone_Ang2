using System;

namespace Silverzone.Entities
{
    public class Dispatch : AuditableEntity<int>
    {
        public string Packet_Id { get; set; }
        public string Invoice_No { get; set; }
        public int OrderId { get; set; }

        public decimal? Packet_Wheight { get; set; }
        public string Packet_Consignment { get; set; }

        public virtual Order Order { get; set; }
        public string print_reason { get; set; }

        public DateTime? Dispatch_Date { get; set; }

        public string Recieved_By{ get; set; }
        public DateTime? Recieved_Date { get; set; }

        public int? CourierModeId { get; set; }
        public virtual CourierMode CourierMode { get; set; }
    }
}
