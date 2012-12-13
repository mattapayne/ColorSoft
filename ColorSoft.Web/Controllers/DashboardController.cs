using System.Web.Mvc;

namespace ColorSoft.Web.Controllers
{
    [Authorize]
    public partial class DashboardController : AbstractController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}