using System.Web.Mvc;
using AutoMapper;
using ColorSoft.Web.Commands.Messages;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Lib;
using ColorSoft.Web.Models.Contact;

namespace ColorSoft.Web.Controllers
{
    public partial class ContactController : AbstractController
    {
        private readonly ICreateMessageCommand _createMessageCommand;
        private readonly IMappingEngine _mappingEngine;

        public ContactController(ICreateMessageCommand createMessageCommand, IMappingEngine mappingEngine)
        {
            _createMessageCommand = createMessageCommand;
            _mappingEngine = mappingEngine;
        }

        public virtual ActionResult Index()
        {
            return View(new MessageViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = _mappingEngine.Map<MessageViewModel, Message>(model);
                _createMessageCommand.Execute(message);
                AddMessageBeforeRedirect(MessageType.Success, "Successfully sent your message.");
                return RedirectToAction(MVC.Contact.Index());
            }

            AddMessagesBeforeRender(MessageType.Error, "Unable to send your message.");
            return View(MVC.Contact.Views.Index, model);
        }
    }
}