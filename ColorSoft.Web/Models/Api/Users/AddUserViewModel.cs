using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ColorSoft.Web.Validation;

namespace ColorSoft.Web.Models.Api.Users
{
    public class AddUserViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailValidation]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Required(ErrorMessage = "Password confirmation is required.")]
        [Compare("Password", ErrorMessage = "Password confirmation must match password")]
        public string PasswordConfirmation { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}