using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Users
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDatabaseProvider _connection;

        public CreateUserCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        #region ICreateUserCommand Members

        public void Execute(User args)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                var defaultRole = trans.Roles.FindAllByName(Role.OrganizationUser).FirstOrDefault();

                trans.Users.Insert(args);
                trans.UsersRoles.Insert(UserId: args.Id, RoleId: defaultRole.Id);

                trans.Commit();
            }
        }

        #endregion
    }
}