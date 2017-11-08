using System;

namespace Silverzone.Entities
{
    public interface IAuditableEntity
    {
        DateTime CreationDate { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdationDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
