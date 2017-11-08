using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silverzone.Web.Areas.Admin.Models
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal OfferPercent { get; set; }
        public decimal OfferAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUpTo { get; set; }
        public bool Status { get; set; }
    }
}