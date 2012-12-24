using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Models.DashboardNavigation
{
    public class DashboardNavigationSectionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<DashboardNavigationSectionItemViewModel> Items { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public DashboardNavigationSectionViewModel()
        {
            Items = new List<DashboardNavigationSectionItemViewModel>();
            Roles = new List<string>();
        }
    }
}