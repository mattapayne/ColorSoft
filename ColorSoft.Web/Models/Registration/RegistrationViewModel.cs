using System.ComponentModel.DataAnnotations;
using ColorSoft.Web.Validation.Validators;
using FluentValidation.Attributes;

namespace ColorSoft.Web.Models.Registration
{
    [Validator(typeof(RegistrationViewModelValidator))]
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
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
    }
}