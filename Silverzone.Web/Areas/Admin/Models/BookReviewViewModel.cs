using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silverzone.Web.Areas.Admin.Models
{
    public class BookReviewViewModel
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string Rating { get; set; }
        public int BookId { get; set; }
    }
}