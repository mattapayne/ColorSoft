using System.Collections.Generic;
using System.Linq;

namespace ColorSoft.Web.Models.DashboardNavigation
{
    public class DashboardNavigationViewModel
    {
        public DashboardNavigationViewModel()
        {
            Sections = Enumerable.Empty<DashboardNavigationSectionViewModel>();
        }

        public IEnumerable<DashboardNavigationSectionViewModel> Sections { get; set; }
    }
}