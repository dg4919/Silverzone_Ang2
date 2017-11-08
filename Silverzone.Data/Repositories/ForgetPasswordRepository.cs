using System.Linq;
using Silverzone.Entities;
using System.IO;

namespace Silverzone.Data
{
    public class ForgetPasswordRepository : BaseRepository<ForgetPassword>, IForgetPasswordRepository
    {
        public ForgetPasswordRepository(SilverzoneContext dbcontext) : base(dbcontext) { }

        public bool sendEmail_forgetPassword(string TemplatePath, int verfiy_code, string emailId)
        {         
            string html = string.Empty;
            using (StreamReader reader = new StreamReader(TemplatePath))
            {
                html = reader.ReadToEnd();
            }

            html = html.Replace("(otpCode)", verfiy_code.ToString());

            ClassUtility.sendMail(emailId, "Password Recovery - Silverzone", html, emailSender.emailNoreply);
            return true;
        }

        public ForgetPassword getRecords (int userId, verificationMode type)
        {
            return FindBy(x => x.UserId == userId && x.verificationMode == type).SingleOrDefault();     // we will get either 1 or 0 record
        }

    }
}
