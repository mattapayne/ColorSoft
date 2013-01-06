using System;
using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public class GetUsersByOrganizationQuery : IGetUsersByOrganizationQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetUsersByOrganizationQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> Execute(Guid organizationId)
        {
            return _connection.Db().Users.FindAllByDeletedAtAndOrganizationId(null, organizationId).
                WithOrganization().
                OrderByCreatedAtDescending();
        }
    }
}