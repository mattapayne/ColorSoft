using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.DashboardNavigation
{
    public class GetDashboardNavigationSectionRolesQuery : IGetDashboardNavigationSectionRolesQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetDashboardNavigationSectionRolesQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public IEnumerable<DashboardNavigationSectionRole> Execute()
        {
            return
                _connection.Db().DashboardNavigationSectionsRoles.All().WithRole();
        }
    }
}