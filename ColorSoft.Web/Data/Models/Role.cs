using System;

namespace ColorSoft.Web.Data.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }

        public const string ColorSoftAdministrator = "ColorSoft Administrator";
        public const string OrganizationAdministrator = "Organization Administrator";
        public const string OrganizationUser = "Organization User";

        public const string AnyAdministrator = "ColorSoft Administrator,Organization Administrator";
    }
}