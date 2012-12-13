using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.DashboardNavigation
{
    public class GetDashboardNavigationQuery : IGetDashboardNavigationQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetDashboardNavigationQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public IEnumerable<DashboardNavigationSection> Execute()
        {
            return _connection.Db().DashboardNavigationSections.FindAllByIsActive(true).WithDashboardNavigationSectionItems();
        }
    }
}