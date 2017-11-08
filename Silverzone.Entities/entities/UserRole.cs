namespace Silverzone.Entities
{
    public  class UserRole:Entity<int>
    {
       public int RoleId { get; set; }
       public virtual Role Role { get; set; }

        public int UserId { get; set; }
       public virtual User User { get; set; }
    }
}
