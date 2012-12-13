using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Commands.Messages;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Contact;
using ColorSoft.Web.Queries.Messages;
using System.Linq;

namespace ColorSoft.Web.Controllers.Api
{
    [Authorize(Roles = "ColorSoft Administrator")]
    public class MessagesController : AuthenticatedApiController
    {
        private readonly IGetMessagesQuery _getMessagesQuery;
        private readonly IDeleteMessageCommand _deleteMessageCommand;

        public MessagesController(IMappingEngine mappingEngine, 
            IGetMessagesQuery getMessagesQuery, 
            IDeleteMessageCommand deleteMessageCommand) 
            : base(mappingEngine)
        {
            _getMessagesQuery = getMessagesQuery;
            _deleteMessageCommand = deleteMessageCommand;
        }

        [HttpGet]
        public IEnumerable<MessageViewModel> Index()
        {
            var messages = _getMessagesQuery.Execute();
            var models = MappingEngine.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messages);
            return models;
        }

        [HttpPost]
        public void Delete(MessageViewModel model)
        {
            if(model.Id.HasValue)
            {
                _deleteMessageCommand.Execute(model.Id.Value);
            }
            else
            {
                throw new ArgumentNullException("model");
            }
        }

        [HttpPost]
        public void DeleteAll(MessageViewModel[] models)
        {
            if(models != null)
            {
               _deleteMessageCommand.Execute(models.Where(m => m.Id.HasValue).Select(m => m.Id.Value).ToArray());
            }
        }
    }
}
