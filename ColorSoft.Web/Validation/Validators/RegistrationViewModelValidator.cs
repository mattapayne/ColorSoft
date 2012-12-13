using ColorSoft.Web.Models.Registration;
using FluentValidation;

namespace ColorSoft.Web.Validation.Validators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(m => m.UserName).NotEmpty().WithMessage("User name is required.");
            RuleFor(m => m.EmailAddress).EmailAddress().WithMessage("A valid email address is required.");
            RuleFor(m => m.PasswordConfirmation).NotEmpty().WithMessage("Password confirmation is required.");
            RuleFor(m => m.Password).NotEmpty().WithMessage("A password is required.").Must(
                (model, password) => password.Length >= 6).WithMessage(
                    "Password must be at least 6 characters in length.").Must(
                        (model, password) => password == model.PasswordConfirmation).WithMessage(
                            "Password must match password confirmation.");

        }
    }
}