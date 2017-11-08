using System.ComponentModel.DataAnnotations;

namespace Silverzone.Api.ViewModel.Admin
{
    public class userViewModel
    {
        [Required]
        public string[]  userName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}