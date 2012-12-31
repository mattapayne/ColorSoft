using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public class GetAllNonDeletedUsersQuery : IGetAllNonDeletedUsersQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetAllNonDeletedUsersQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        #region IGetAllNonDeletedUsersQuery Members

        public IEnumerable<User> Execute()
        {
            return _connection.Db().Users.FindAllByDeletedAt(null).
                WithOrganization().
                OrderByCreatedAtDescending();
        }

        #endregion
    }
}