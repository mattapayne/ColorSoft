using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Messages
{
    public interface IGetMessagesQuery : IQuery
    {
        IEnumerable<Message> Execute();
    }
}
