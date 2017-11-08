namespace Silverzone.Entities
{
    public class Role:AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool is_Active { get; set; }
    }
}
