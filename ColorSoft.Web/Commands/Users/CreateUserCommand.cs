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
                trans.Users.Insert(FirstName: args.FirstName, LastName: args.LastName, EmailAddress: args.EmailAddress, 
                    HashedPassword: args.HashedPassword, UserName: args.UserName);
                trans.Commit();
            }
        }

        #endregion
    }
}