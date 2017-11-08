namespace Silverzone.Entities
{
    public class classSubject : AuditableEntity<int> 
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subjects { get; set; }

    }
}
