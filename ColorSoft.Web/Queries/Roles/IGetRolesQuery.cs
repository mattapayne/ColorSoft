using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Roles
{
    public interface IGetRolesQuery : IQuery
    {
        IEnumerable<Role> Execute();
    }
}
