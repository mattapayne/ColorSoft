using System.Collections.Generic;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Messages
{
    public class GetMessagesQuery : IGetMessagesQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetMessagesQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public IEnumerable<Message> Execute()
        {
            return _connection.Db().Messages.All().OrderByCreatedAtDescending();
        }
    }
}