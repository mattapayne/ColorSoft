using System;

namespace ColorSoft.Web.Data.Models
{
    public class DashboardNavigationSectionRole
    {
        public Guid DashboardNavigationSectionId { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}