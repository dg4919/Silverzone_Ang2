using System.Linq;
using Silverzone.Entities;

namespace Silverzone.Data
{
    public class GenericOTPRepository : BaseRepository<GenericOTP>, IGenericOTPRepository
    {
        public GenericOTPRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public GenericOTP GetByMobile(string mobileNo)
        {
            return FindBy(x => x.mobileNo == mobileNo).FirstOrDefault();
        }

   
    }
}
