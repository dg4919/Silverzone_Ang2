using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IGenericOTPRepository : IRepository<GenericOTP>
    {
        GenericOTP GetByMobile(string mobileNo);
    }
}
