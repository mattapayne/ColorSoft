using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Organizations
{
    public class CreateOrganizationCommand : ICreateOrganizationCommand
    {
        private readonly IDatabaseProvider _connection;

        public CreateOrganizationCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public void Execute(Organization organization)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                trans.Organizations.Insert(organization);
                trans.Commit();
            }
        }
    }
}