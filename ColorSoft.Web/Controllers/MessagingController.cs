using System.Web.Mvc;

namespace ColorSoft.Web.Controllers
{
    public partial class MessagingController : AbstractController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}