using System.ComponentModel.DataAnnotations;

namespace Silverzone.Entities
{
    public class OlympiadList:Entity<int>
    {
        [MaxLength(50)]
        public string OlympiadName { get; set; }
       [DataType(DataType.Date)]
        public string FirstDate { get; set; }
        [DataType(DataType.Date)]
        public string SecondDate { get; set; }
        [DataType(DataType.Date)]
        public string LastDateOfRegistration { get; set; }
        public bool Status { get; set; }
    }
}
