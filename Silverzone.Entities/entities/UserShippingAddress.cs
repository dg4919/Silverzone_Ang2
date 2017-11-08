using System;

namespace Silverzone.Entities
{
    public class UserShippingAddress:Entity<int>
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public countryType CountryType { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public DateTime create_date { get; set; }
        public bool is_Active { get; set; }        
    }
}
