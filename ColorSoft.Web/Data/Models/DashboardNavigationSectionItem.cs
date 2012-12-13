using System;

namespace ColorSoft.Web.Data.Models
{
    public class DashboardNavigationSectionItem
    {
        public Guid Id { get; set; }
        public Guid DashboardNavigationSectionId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdminOnly { get; set; }
    }
}