using System;
using ColorSoft.Web.Data;

namespace ColorSoft.Web.Commands.Messages
{
    public class DeleteMessageCommand : IDeleteMessageCommand
    {
        private readonly IDatabaseProvider _connection;

        public DeleteMessageCommand(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public void Execute(params Guid[] ids)
        {
            if(ids == null)
            {
                return;
            }

            using (dynamic trans = _connection.Db().BeginTransaction())
            {
                foreach(var id in ids)
                {
                    trans.Messages.DeleteById(id);   
                }

                trans.Commit();
            }
        }
    }
}