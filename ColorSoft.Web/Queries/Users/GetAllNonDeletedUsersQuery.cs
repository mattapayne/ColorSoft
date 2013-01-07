using System.Collections.Generic;
using System.Linq;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Queries.Users
{
    public class GetAllNonDeletedUsersQuery : IGetAllNonDeletedUsersQuery
    {
        private readonly IDatabaseProvider _connection;
        private readonly IApplicationUser _user;

        public GetAllNonDeletedUsersQuery(IDatabaseProvider connection, IApplicationUser user)
        {
            _connection = connection;
            _user = user;
        }

        #region IGetAllNonDeletedUsersQuery Members

        public IEnumerable<User> Execute()
        {
            if(_user.IsInRole(Role.ColorSoftAdministrator))
            {
                return _connection.Db().Users.FindAllByDeletedAt(null).
                    WithOrganization().
                    OrderByCreatedAtDescending();
            }

            if(_user.IsInRole(Role.OrganizationAdministrator) && _user.OrganizationId.HasValue)
            {
                return _connection.Db().Users.FindAllByDeletedAtAndOrganizationId(null, _user.OrganizationId.Value).
                    WithOrganization().
                    OrderByCreatedAtDescending();
            }

            return Enumerable.Empty<User>();
        }

        #endregion
    }
}