using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Users
{
    public interface IUpdateUserCommand : ICommand
    {
        void Execute(User user);
    }
}