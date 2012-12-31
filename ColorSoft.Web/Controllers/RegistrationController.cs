using System.Web.Mvc;

namespace ColorSoft.Web.Controllers
{
    public partial class RegistrationController : Controller
    {
        public virtual JsonResult Create()
        {
            return Json(new {Success = true});
        }
    }
}
