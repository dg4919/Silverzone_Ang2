using System;
namespace Silverzone.Entities
{
    public class AuditableEntity<T>:Entity<T>,IAuditableEntity
    {
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdationDate { get; set;}
        public string UpdatedBy{ get; set; }
    }
}
