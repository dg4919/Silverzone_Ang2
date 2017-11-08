using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class Book:AuditableEntity<int>
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string BookImage { get; set; }
        [MaxLength(100)]
        public string ISBN { get; set; }
        [MaxLength(100)]
        public string Publisher { get; set; }
        [MaxLength(100)]
        public string Edition { get; set; }
        public int Pages { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool is_Active { get; set; }
        public bool in_Stock { get; set; }

        public virtual BookDetail BookDetails { get; set; }
        public virtual ICollection<BookContent> BookContents { get; set; }
        public virtual ICollection<BookReview> BookReviews { get; set; }
        
    }
}
