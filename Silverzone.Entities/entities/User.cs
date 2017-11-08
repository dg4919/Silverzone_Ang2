using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silverzone.Entities
{
    public class User:Entity<int>
    {
        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        [MaxLength(200)]
        public string ProfilePic { get; set; }

        // type is suffix if create colum in DB to identify column is a type of Enum
        public genderType? GenderType { get; set; }       // get from Enum

        [Column(TypeName = "Date")]         // to create a date type column in DB
        public DateTime? DOB { get; set; }          // 2 ways making value nullable

        public Nullable<int> ClassId { get; set; }
        public virtual Class Class { get; set; }

        [MaxLength(100)]
        [EmailAddress(ErrorMessage="Enter Valid Email ID")]
        public string EmailID { get; set; }
       
        //public bool EmailConfirmed { get; set; }

        public string MobileNumber { get; set; }

        //public bool MobileNumberConfirmed { get; set; }

        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string OperatingSystem { get; set; }
        public string Location { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }

        public int TotalPoint { get; set; }

        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<UserQuizPoints> QuizPoints { get; set; }
    }
}
