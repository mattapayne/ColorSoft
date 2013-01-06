using System;
using System.Linq;
using ColorSoft.Web.Commands.Users;
using ColorSoft.Web.Data;
using ColorSoft.Web.Queries.Users;

namespace ColorSoft.Web.Commands.Organizations
{
    public class DeleteOrganizationCommand : IDeleteOrganizationCommand
    {
        private readonly IDatabaseProvider _connection;
        private readonly IDeleteUserCommand _deleteUserCommand;
        private readonly IGetUsersByOrganizationQuery _getUsersByOrganizationQuery;

        public DeleteOrganizationCommand(IDatabaseProvider connection, 
            IDeleteUserCommand deleteUserCommand, 
            IGetUsersByOrganizationQuery getUsersByOrganizationQuery)
        {
            _connection = connection;
            _deleteUserCommand = deleteUserCommand;
            _getUsersByOrganizationQuery = getUsersByOrganizationQuery;
        }

        public void Execute(Guid id)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                var users = _getUsersByOrganizationQuery.Execute(id);
                users.ToList().ForEach(u => _deleteUserCommand.Execute(u.Id));
                trans.Organizations.DeleteById(id);
                trans.Commit();
            }

        }
    }
}