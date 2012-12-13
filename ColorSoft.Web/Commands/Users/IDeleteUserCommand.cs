using System;

namespace ColorSoft.Web.Commands.Users
{
    public interface IDeleteUserCommand : ICommand
    {
        void Execute(Guid id);
    }
}