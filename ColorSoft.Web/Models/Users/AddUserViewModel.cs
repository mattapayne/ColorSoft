using System.ComponentModel.DataAnnotations;

namespace ColorSoft.Web.Models.Users
{
    public class AddUserViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        public string PasswordConfirmation { get; set; }
    }
}