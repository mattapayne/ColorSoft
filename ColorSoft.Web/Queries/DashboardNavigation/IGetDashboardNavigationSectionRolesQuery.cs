using System;
using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.DashboardNavigation
{
    public interface IGetDashboardNavigationSectionRolesQuery : IQuery
    {
        IEnumerable<DashboardNavigationSectionRole> Execute();
    }
}
