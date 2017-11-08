using System;

namespace Silverzone.Entities
{
    public class UserLogs:Entity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Login_DateTime { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string Location { get; set; }
    }
}
