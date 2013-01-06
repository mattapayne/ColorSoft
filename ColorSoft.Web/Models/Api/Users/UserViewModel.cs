using System;

namespace ColorSoft.Web.Models.Api.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string CreatedAt { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationId { get; set; }
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}