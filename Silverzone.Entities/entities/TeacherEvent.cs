namespace Silverzone.Entities
{
    public class TeacherEvent : Entity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
