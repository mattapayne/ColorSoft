using System;

namespace ColorSoft.Web.Commands.Messages
{
    public interface IDeleteMessageCommand : ICommand
    {
        void Execute(params Guid[] ids);
    }
}
