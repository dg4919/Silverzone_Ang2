using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Silverzone.Entities
{
    public class Subject:AuditableEntity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public ICollection<classSubject> classSubjects { get; set; }
    }
}
