using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Commands.Messages;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.Messages;

namespace ColorSoft.Web.Controllers.Api
{
    public class ContactController : ApiController
    {
        private readonly IMappingEngine _mappingEngine;
        private readonly ICreateMessageCommand _createMessageCommand;

        public ContactController(IMappingEngine mappingEngine, ICreateMessageCommand createMessageCommand)
        {
            _mappingEngine = mappingEngine;
            _createMessageCommand = createMessageCommand;
        }


        [HttpPost]
        public void Create(MessageViewModel model)
        {
            if (model != null)
            {
                _createMessageCommand.Execute(_mappingEngine.Map<MessageViewModel, Message>(model));
            }
        }
    }
}
