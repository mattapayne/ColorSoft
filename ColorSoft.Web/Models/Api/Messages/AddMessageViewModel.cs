using System.ComponentModel.DataAnnotations;

namespace ColorSoft.Web.Models.Api.Messages
{
    public class AddMessageViewModel
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "An email address is required.")]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "A subject is required.")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "A message is required.")]
        public string Message { get; set; }
    }
}