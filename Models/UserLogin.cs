using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class UserLogin
    {
        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

    }
}
