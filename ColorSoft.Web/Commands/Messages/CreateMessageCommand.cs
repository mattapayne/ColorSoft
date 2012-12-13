using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Commands.Messages
{
    public class CreateMessageCommand : ICreateMessageCommand
    {
        private readonly IDatabaseProvider _connection;

        public CreateMessageCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public void Execute(Message message)
        {
            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                trans.Messages.Insert(Subject: message.Subject, MessageText: message.MessageText, From: message.From);
                trans.Commit();
            }
        }
    }
}