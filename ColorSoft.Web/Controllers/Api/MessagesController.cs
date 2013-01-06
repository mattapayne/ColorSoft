using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Commands.Messages;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Filters;
using ColorSoft.Web.Models.Api.Messages;
using ColorSoft.Web.Queries.Messages;

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
        [ModelRequired(ModelParameterName = "ids")]
        public HttpResponseMessage Delete(Guid[] ids)
        {
            try
            {
                _deleteMessageCommand.Execute(ids);
                return DeletedResponse();
            }
            catch (Exception ex)
            {
                return ExceptionErrorResponse(ex);
            }
        }
    }
}
