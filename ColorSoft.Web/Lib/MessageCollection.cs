using System.Collections.Generic;
using System.Linq;

namespace ColorSoft.Web.Lib
{
    public class MessageCollection
    {
        public const string MessagesKey = "__MESSAGES__";

        public MessageType Type { get; private set; }
        public IEnumerable<string> Messages { get; private set; } 

        public MessageCollection(MessageType messageType, IEnumerable<string> messages)
        {
            Messages = messages ?? Enumerable.Empty<string>();

            Type = Messages.Any() ? messageType : MessageType.None;
        }
    }
}