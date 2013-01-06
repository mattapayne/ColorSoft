using System;

namespace ColorSoft.Web.Commands.Organizations
{
    public interface IDeleteOrganizationCommand : ICommand
    {
        void Execute(Guid id);
    }
}
