using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IDispatchRepository : IRepository<Dispatch>
    {
        string get_Packet_Number(int identityValue);
        string get_Invoice_Number(int identityValue);
        bool is_orderExist(int orderId);
        Dispatch GetByorderId(int orderid);
        Dispatch GetBypacketId(string packetNumber);
        bool GetByConsignment(string consignmentNo, int dispatchId);

    }
}
