using System;
using ColorSoft.Web.Data;

namespace ColorSoft.Web.Commands.Users
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDatabaseProvider _connection;

        public DeleteUserCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        #region IDeleteUserCommand Members

        public void Execute(Guid args)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                trans.Users.DeleteById(args);
                trans.Commit();
            }
        }

        #endregion
    }
}