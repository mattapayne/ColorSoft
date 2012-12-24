using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Data.Models
{
    public class DashboardNavigationSection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public ICollection<DashboardNavigationSectionItem> DashboardNavigationSectionItems { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public DashboardNavigationSection()
        {
            DashboardNavigationSectionItems = new List<DashboardNavigationSectionItem>();
            Roles = new List<Role>();
        }
    }
}