using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Models.DashboardNavigation
{
    public class DashboardNavigationSectionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdminOnly { get; set; }
        public IEnumerable<DashboardNavigationSectionItemViewModel> Items { get; set; }
    }
}