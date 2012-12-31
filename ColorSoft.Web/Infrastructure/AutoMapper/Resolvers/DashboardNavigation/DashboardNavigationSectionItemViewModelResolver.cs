using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.DashboardNavigation;
using WebGrease.Css.Extensions;

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
            var items =
                source.DashboardNavigationSectionItems.
                    Where(x => x.IsActive).
                    OrderBy(x => x.SortOrder).
                    Select(
                        item =>
                        _mappingEngine.Map<DashboardNavigationSectionItem, DashboardNavigationSectionItemViewModel>(item)).ToList();
            items.ForEach(i => i.DashboardNavigationSectionName = source.Name);
            return items;
        }
    }
}