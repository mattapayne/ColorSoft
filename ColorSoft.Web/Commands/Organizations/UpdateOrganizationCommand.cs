using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Organizations
{
    public class UpdateOrganizationCommand : IUpdateOrganizationCommand
    {
        private readonly IDatabaseProvider _connection;

        public UpdateOrganizationCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public void Execute(Organization organization)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                trans.Organizations.UpdateById(organization);
                trans.Commit();
            }
        }
    }
}