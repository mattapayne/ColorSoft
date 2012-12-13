using ColorSoft.Web.Models.Authentication;
using FluentValidation;

namespace ColorSoft.Web.Validation.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Your login name is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password is required.");
        }
    }
}