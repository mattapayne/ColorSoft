using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Organizations
{
    public interface IGetOrganizationsQuery : IQuery
    {
        IEnumerable<Organization> Execute();
    }
}
