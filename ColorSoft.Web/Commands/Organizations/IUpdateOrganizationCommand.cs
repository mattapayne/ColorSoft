using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Organizations
{
    public interface IUpdateOrganizationCommand : ICommand
    {
        void Execute(Organization organization);
    }
}
