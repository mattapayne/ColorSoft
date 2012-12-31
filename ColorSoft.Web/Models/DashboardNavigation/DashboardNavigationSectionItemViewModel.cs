using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Models.DashboardNavigation
{
    public class DashboardNavigationSectionItemViewModel
    {
        public Guid Id { get; set; }
        public Guid DashboardNavigationSectionId { get; set; }
        public string DashboardNavigationSectionName { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public DashboardNavigationSectionItemViewModel()
        {
            Roles = new List<string>();
        }

        public string FullPath
        {
            get { return string.Format("{0}/{1}", DashboardNavigationSectionName, Name); }
        }
    }
}