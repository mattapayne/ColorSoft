using System;
using System.ComponentModel.DataAnnotations;

namespace ColorSoft.Web.Models.Api.Users
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string CreatedAt { get; set; }

        public string OrganizationName { get; set; }
    }
}