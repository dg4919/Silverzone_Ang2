using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silverzone.Web.Areas.Admin.Models
{
    public class ContentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int BookId { get; set; }
    }
}