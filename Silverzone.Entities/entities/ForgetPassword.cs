using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    [Table("Forget_Password")]
    public class ForgetPassword : verification
    {
        public verificationMode verificationMode { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public abstract class verification : Entity<int>
    {
        public int sms_code { get; set; }
        public int max_attempt { get; set; }
        public DateTime valid_time { get; set; }
        public DateTime max_attempt_unlock_date { get; set; }
    }


}
