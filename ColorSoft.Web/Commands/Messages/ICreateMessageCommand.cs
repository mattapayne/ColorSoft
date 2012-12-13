using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Messages
{
    public interface ICreateMessageCommand : ICommand
    {
        void Execute(Message message);
    }
}
