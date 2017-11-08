using Silverzone.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Silverzone.Api.ViewModel.Site
{
    public class UserProfileViewModel
    {
        public int? Class { get; set; }
        public string ProfilePic { get; set; }

        // no need to suffix with type as we r not going to create column in DB with this Name
        public genderType? Gender { get; set; }

        // it discard time intervals > set to its default value : 12:00:00
        [DataType(DataType.Date)]     // means can hold > date Type value
        public DateTime? DOB { get; set; }

        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string Role { get; set; }
        
        // bcoz of solving problem of > A circular reference was detected while serializing an object
        internal static UserProfileViewModel Parse(User user)
        {
            var userInfo = new UserProfileViewModel
            {
                UserName = user.UserName,
                Class = user.ClassId,
                DOB = user.DOB,
                EmailID = user.EmailID,
                Gender = user.GenderType,
                MobileNumber = user.MobileNumber,
                ProfilePic = user.ProfilePic,
                Role = user.Role.Name
            };

            return userInfo;
        }


    }
}