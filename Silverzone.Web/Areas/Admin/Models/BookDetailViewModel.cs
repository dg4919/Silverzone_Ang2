using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silverzone.Web.Areas.Admin.Models
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string BookDesription { get; set; }
        public int ContentId { get; set; }
        public int BookId { get; set; }
    }
}