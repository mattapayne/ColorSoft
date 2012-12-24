using System;

namespace ColorSoft.Web.Data.Models
{
    public class DashboardNavigationSectionItemRole
    {
        public Guid RoleId { get; set; }
        public Guid DashboardNavigationSectionItemId { get; set; }
        public Role Role { get; set; }
    }
}