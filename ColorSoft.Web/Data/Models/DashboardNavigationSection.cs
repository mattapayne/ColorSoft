using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Data.Models
{
    public class DashboardNavigationSection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdminOnly { get; set; }
        public ICollection<DashboardNavigationSectionItem> DashboardNavigationSectionItems { get; set; }

        public DashboardNavigationSection()
        {
            DashboardNavigationSectionItems = new List<DashboardNavigationSectionItem>();
        }
    }
}