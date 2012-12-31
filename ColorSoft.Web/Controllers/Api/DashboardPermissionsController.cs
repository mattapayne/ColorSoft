using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.DashboardPermissions;
using ColorSoft.Web.Queries.DashboardNavigation;

namespace ColorSoft.Web.Controllers.Api
{
    public class DashboardPermissionsController : AuthenticatedApiController
    {
        private readonly IGetDashboardNavigationQuery _getDashboardNavigationQuery;

        public DashboardPermissionsController(IMappingEngine mappingEngine, IGetDashboardNavigationQuery getDashboardNavigationQuery) 
            : base(mappingEngine)
        {
            _getDashboardNavigationQuery = getDashboardNavigationQuery;
        }

        [HttpGet]
        public IEnumerable<DashboardPermissionViewModel> Index()
        {
            var dashboard = _getDashboardNavigationQuery.Execute();
            var accessibleItems =
                dashboard.SelectMany(x => x.DashboardNavigationSectionItems).Where(
                    item => item.Roles.Any(role => CurrentUser.IsInRole(role.Name))).ToList();

            var items =
                MappingEngine.Map
                    <IEnumerable<DashboardNavigationSectionItem>, IEnumerable<DashboardPermissionViewModel>>(
                        accessibleItems);

            return items;
        }
    }
}
