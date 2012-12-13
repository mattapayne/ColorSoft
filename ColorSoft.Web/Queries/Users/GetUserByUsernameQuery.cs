using System.Collections.Generic;
using System.Linq;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public class GetUserByUsernameQuery : IGetUserByUsernameQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetUserByUsernameQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        #region IGetUserByUsernameQuery Members

        public User Execute(string userName, bool includeRoles = false)
        {
            User user = _connection.Db().Users.FindAllByUserName(userName).FirstOrDefault();  

            if(user != null && includeRoles)
            {
                IEnumerable<UserRole> usersRoles = _connection.Db().UsersRoles.FindAllByUserId(user.Id);

                if(usersRoles.Any())
                {
                    IEnumerable<Role> roles = _connection.Db().Roles.FindAllById(usersRoles.Select(ur => ur.RoleId));

                    if(roles.Any())
                    {
                        user.Roles = roles.Select(r => r.Name).ToList();
                    }
                }
            }

            return user;
        }

        #endregion
    }
}