using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Users
{
    public interface ICreateUserCommand : ICommand
    {
        void Execute(User user);
    }
}