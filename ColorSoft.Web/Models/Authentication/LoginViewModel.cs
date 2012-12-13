using ColorSoft.Web.Validation.Validators;
using FluentValidation.Attributes;

namespace ColorSoft.Web.Models.Authentication
{
    [Validator(typeof (LoginViewModelValidator))]
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}