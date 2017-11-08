using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class OrderDetailRepository:BaseRepository<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public OrderDetail GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<OrderDetail> GetByOrderId(int id)
        {
            return _dbset.Where(x => x.OrderId == id).AsEnumerable();
        }
      

    }
}
