using System.Web.Mvc;
using ColorSoft.Web.Infrastructure.Authentication;

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
    }
}