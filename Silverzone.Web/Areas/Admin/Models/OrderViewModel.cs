﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silverzone.Web.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}