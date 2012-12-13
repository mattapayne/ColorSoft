using System;
using System.ComponentModel.DataAnnotations;
using ColorSoft.Web.Validation.Validators;
using FluentValidation.Attributes;

namespace ColorSoft.Web.Models.Contact
{
    [Validator(typeof(MessageViewModelValidator))]
    public class MessageViewModel
    {
        public Guid? Id { get; set; }

        public string CreatedAt { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}