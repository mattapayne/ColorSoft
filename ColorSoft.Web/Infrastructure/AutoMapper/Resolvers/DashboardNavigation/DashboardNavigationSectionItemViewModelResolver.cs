using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.DashboardNavigation;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Resolvers.DashboardNavigation
{
    public class DashboardNavigationSectionItemViewModelResolver : ValueResolver<DashboardNavigationSection, IEnumerable<DashboardNavigationSectionItemViewModel>>
    {
        private readonly IMappingEngine _mappingEngine;

        public DashboardNavigationSectionItemViewModelResolver(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        protected override IEnumerable<DashboardNavigationSectionItemViewModel> ResolveCore(DashboardNavigationSection source)
        {
            return
                source.DashboardNavigationSectionItems.Select(
                    item =>
                    _mappingEngine.Map<DashboardNavigationSectionItem, DashboardNavigationSectionItemViewModel>(item));
        }
    }
}