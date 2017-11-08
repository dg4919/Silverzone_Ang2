using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface IForgetPasswordRepository : IRepository<ForgetPassword>
    {
        bool sendEmail_forgetPassword(string TemplatePath, int verfiy_code, string emailId);
        ForgetPassword getRecords(int userId, verificationMode type);

    }
}
