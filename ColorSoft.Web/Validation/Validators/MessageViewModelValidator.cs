using ColorSoft.Web.Models.Contact;
using FluentValidation;

namespace ColorSoft.Web.Validation.Validators
{
    public class MessageViewModelValidator : AbstractValidator<MessageViewModel>
    {
        public MessageViewModelValidator()
        {
            RuleFor(m => m.Email).NotEmpty().WithMessage("An email address is required.").EmailAddress().WithMessage(
                "A valid email address is required.");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Please enter a subject.").Length(1, 100).WithMessage(
                "Subject must be no longer than 100 characters.");
            RuleFor(m => m.Message).NotEmpty().WithMessage("Please enter a message.");
        }
    }
}