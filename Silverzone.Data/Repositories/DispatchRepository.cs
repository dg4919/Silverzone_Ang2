using System.Linq;
using Silverzone.Entities;

namespace Silverzone.Data
{
    public class DispatchRepository : BaseRepository<Dispatch>, IDispatchRepository
    {
        public DispatchRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public Dispatch GetByorderId(int orderid)
        {
            return FindBy(x => x.OrderId == orderid).SingleOrDefault();  // there will be always 1 record
        }

        public bool GetByConsignment(string consignmentNo, int dispatchId)
        {
            //return _dbset.Any(x => x.Packet_Consignment.Contains(consignmentNo) && x.Id != dispatchId);    // use for like condison
            return _dbset.Any(x => x.Packet_Consignment == consignmentNo && x.Id != dispatchId);
        }

        public Dispatch GetBypacketId(string packetNumber)
        {
            return FindBy(x => x.Packet_Id.Equals(packetNumber)).SingleOrDefault();
        }

        public bool is_orderExist(int orderId)
        {
            return _dbset.Any(x => x.OrderId == orderId);
        }

        public string get_Packet_Number(int identityValue)
        {                    
            int packet_number = 1000000;

            var order_date = string.Format("{0: yyyyMMdd}", get_DateTime()).Trim();

            return (string.Format("PKT/ONL{0}/{1}", order_date, packet_number + identityValue));
        }


        public string get_Invoice_Number(int identityValue)
        {
            int packet_number = 1000000;
            string invoiceNo = (packet_number + identityValue).ToString();

            return (invoiceNo);
        }

    }
}
