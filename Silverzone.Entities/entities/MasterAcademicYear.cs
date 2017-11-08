using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class MasterAcademicYear:Entity<int>
    {
        [MaxLength(7)]
        public string CurrentAcademicYear { get; set; }
        [MaxLength(7)]
        public string LastAcademicYear { get; set; }
        [MaxLength(80)]
        public  string CurrentEventCodes { get; set; }
        [MaxLength(80)]
        public string LastEventCodes { get; set; }
    }
}
