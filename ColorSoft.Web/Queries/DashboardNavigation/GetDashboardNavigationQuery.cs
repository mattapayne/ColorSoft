using System.Collections.Generic;
using System.Linq;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.DashboardNavigation
{
    public class GetDashboardNavigationQuery : IGetDashboardNavigationQuery
    {
        private readonly IDatabaseProvider _connection;
        private readonly IGetDashboardNavigationSectionRolesQuery _getDashboardNavigationSectionRolesQuery;
        private readonly IGetDashboardNavigationSectionItemRolesQuery _getDashboardNavigationSectionItemRolesQuery;

        public GetDashboardNavigationQuery(IDatabaseProvider connection, 
            IGetDashboardNavigationSectionItemRolesQuery getDashboardNavigationSectionItemRolesQuery, 
            IGetDashboardNavigationSectionRolesQuery getDashboardNavigationSectionRolesQuery)
        {
            _connection = connection;
            _getDashboardNavigationSectionItemRolesQuery = getDashboardNavigationSectionItemRolesQuery;
            _getDashboardNavigationSectionRolesQuery = getDashboardNavigationSectionRolesQuery;
        }

        public IEnumerable<DashboardNavigationSection> Execute()
        {
            IEnumerable<DashboardNavigationSection> results =
                _connection.Db().DashboardNavigationSections.
                    FindAllByIsActive(true).
                    WithDashboardNavigationSectionItems();

            results = results.ToList();

            IEnumerable<DashboardNavigationSectionRole> sectionRoles = _getDashboardNavigationSectionRolesQuery.Execute().ToList();
            IEnumerable<DashboardNavigationSectionItemRole> itemRoles = _getDashboardNavigationSectionItemRolesQuery.Execute();

            foreach (var dashboardNavigationSection in results)
            {
                dashboardNavigationSection.Roles = sectionRoles.
                    Where(x => x.DashboardNavigationSectionId == dashboardNavigationSection.Id).
                    Select(x => x.Role).
                    ToList();

                foreach(var item in dashboardNavigationSection.DashboardNavigationSectionItems)
                {
                    item.Roles = itemRoles.
                        Where(x => x.DashboardNavigationSectionItemId == item.Id).
                        Select(x => x.Role).
                        ToList();
                }
            }

            return results;
        }
    }
}