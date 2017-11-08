using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class TeacherDetail : Entity<int>
    {
        [ForeignKey("Id")]
        public User User { get; set; }

        [Required]
        public string SchoolName { get; set; }

        public string SchoolCode { get; set; }

        [MaxLength(200)]
        public string SchoolAddress { get; set; }

        [Required]
        public int PinCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }
       
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
       
        [Required]
        public bool is_Active { get; set; }

       
    }
}
