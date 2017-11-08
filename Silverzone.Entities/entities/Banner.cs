namespace Silverzone.Entities
{
    public class Banner:Entity<int>
    {
        public string ImageName { get; set; }
        public string Caption { get; set; }
        public string Link { get; set; }
        public bool Status { get; set; }
    }
}
