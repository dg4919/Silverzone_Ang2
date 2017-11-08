using System.Collections.Generic;
using System.Linq;
using Silverzone.Entities;
namespace Silverzone.Data
{
    public class UserShippingAddressRepository:BaseRepository<UserShippingAddress>,IUserShippingAddressRepository
    {
        public UserShippingAddressRepository(SilverzoneContext dbcontext):base(dbcontext){ }
        public UserShippingAddress GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
        public IEnumerable<UserShippingAddress> GetByUserId(int id)
        {
            return FindBy(x => x.UserId == id && x.is_Active == true).AsEnumerable();
        }
    }
}
