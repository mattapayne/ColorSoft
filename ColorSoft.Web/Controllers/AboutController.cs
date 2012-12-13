using System.Web.Mvc;

namespace ColorSoft.Web.Controllers
{
    public partial class AboutController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}