using System.Collections.Generic;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IUserShippingAddressRepository:IRepository<UserShippingAddress>
    {
        UserShippingAddress GetById(int id);
        IEnumerable<UserShippingAddress> GetByUserId(int id);
    }
}
