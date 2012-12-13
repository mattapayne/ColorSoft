using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Users
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDatabaseProvider _connection;

        public UpdateUserCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        #region IUpdateUserCommand Members

        public void Execute(User args)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                trans.Users.UpdateById(args);
                trans.Commit();
            }
        }

        #endregion
    }
}