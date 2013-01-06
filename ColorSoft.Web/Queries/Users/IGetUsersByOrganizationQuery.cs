using System;
using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public interface IGetUsersByOrganizationQuery : IQuery
    {
        IEnumerable<User> Execute(Guid organizationId);
    }
}
