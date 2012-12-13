using System.Web.Mvc;
using ColorSoft.Web.Infrastructure.Authentication;
using ColorSoft.Web.Lib;

namespace ColorSoft.Web.Controllers
{
    public abstract partial class AbstractController : Controller
    {
        protected AbstractController()
        {
            ViewBag.CurrentUser = CurrentUser;
        }

        protected ColorSoftPrincipal CurrentUser
        {
            get
            {
                if (HttpContext != null)
                {
                    return HttpContext.User as ColorSoftPrincipal;
                }

                return null;
            }
        }

        protected void AddMessageBeforeRedirect(MessageType messageType, params string[] messages)
        {
            TempData.Add(MessageCollection.MessagesKey, new MessageCollection(messageType, messages));
        }

        protected void AddMessagesBeforeRender(MessageType messageType, params string[] messages)
        {
            ViewData.Add(MessageCollection.MessagesKey, new MessageCollection(messageType, messages));
        }
    }
}