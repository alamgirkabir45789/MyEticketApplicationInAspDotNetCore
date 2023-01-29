using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class UserRegistration
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
