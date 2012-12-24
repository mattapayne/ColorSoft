using System;
using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.DashboardNavigation
{
    public class GetDashboardNavigationSectionItemRolesQuery : IGetDashboardNavigationSectionItemRolesQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetDashboardNavigationSectionItemRolesQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public IEnumerable<DashboardNavigationSectionItemRole> Execute()
        {
            return
                _connection.Db().DashboardNavigationSectionItemsRoles.All().WithRole();
        }
    }
}