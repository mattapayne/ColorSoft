using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ColorSoft.Web.Validation;

namespace ColorSoft.Web.Models.Api.Registration
{
    public class RegistrationViewModel
    {
        [Display(Name = "Your Organization")]
        public string OrganizationName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailValidation]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password confirmation must match password")]
        public string PasswordConfirmation { get; set; }
    }
}