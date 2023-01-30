using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class UserRegistration
    {
      
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and confirm password not matched")]
        public string ConfirmPassword { get; set; }
    }
}
