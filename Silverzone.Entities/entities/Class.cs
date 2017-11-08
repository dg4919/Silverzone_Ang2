using System.Collections.Generic;

namespace Silverzone.Entities
{
    public class Class : AuditableEntity<int>
    {
       public string className { get; set; }

        public virtual ICollection<classSubject> classSubjects { get; set; }
        public virtual ICollection<Book> books { get; set; }
    }

}
