using System.Collections.Generic;
using System.Linq;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Queries.Roles
{
    public class GetRolesLimitedByCurrentUserQuery : IGetRolesLimitedByCurrentUserQuery
    {
        private readonly IDatabaseProvider _connection;
        private readonly IApplicationUser _user;

        public GetRolesLimitedByCurrentUserQuery(IDatabaseProvider connection, IApplicationUser user)
        {
            _connection = connection;
            _user = user;
        }

        public IEnumerable<Role> Execute()
        {
            IEnumerable<UserRole> usersRoles = _connection.Db().UsersRoles.FindAllByUserId(_user.Id);
            IEnumerable<Role> allRoles = _connection.Db().Roles.All();

            if (usersRoles.Any())
            {
                IEnumerable<Role> rolesAssignedToUser = _connection.Db().Roles.FindAllById(usersRoles.Select(ur => ur.RoleId));

                if (rolesAssignedToUser.Any())
                {
                    var minRank = rolesAssignedToUser.Min(r => r.Rank);
                    return allRoles.Where(r => r.Rank >= minRank);
                }
            }

            return Enumerable.Empty<Role>();
        }
    }
}