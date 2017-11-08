using System;
using System.Collections.Generic;
using System.Linq;
namespace Silverzone.Web.Areas.Admin.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public int Pages { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
    }
}