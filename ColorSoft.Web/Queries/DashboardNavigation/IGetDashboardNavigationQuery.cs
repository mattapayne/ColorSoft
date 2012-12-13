using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.DashboardNavigation
{
    public interface IGetDashboardNavigationQuery : IQuery
    {
        IEnumerable<DashboardNavigationSection> Execute();
    }
}
