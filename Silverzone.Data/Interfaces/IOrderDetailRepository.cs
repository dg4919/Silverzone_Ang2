using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
        OrderDetail GetById(int id);
        IEnumerable<OrderDetail> GetByOrderId(int id);
    }
}
