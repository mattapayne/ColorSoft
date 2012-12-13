using System.Web.Mvc;
using ColorSoft.Web.Models.Home;

namespace ColorSoft.Web.Controllers
{
    public partial class HomeController : AbstractController
    {
        public virtual ActionResult Index(LoginAttemptViewModel model)
        {
            return View(model);
        }
    }
}