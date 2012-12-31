using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Organizations
{
    public interface ICreateOrganizationCommand : ICommand
    {
        void Execute(Organization organization);
    }
}
