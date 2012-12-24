using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Roles
{
    public class GetRolesQuery : IGetRolesQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetRolesQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public IEnumerable<Role> Execute()
        {
            return _connection.Db().Roles.All();
        }
    }
}