using System.Web.Mvc;
using ColorSoft.Web.Models.Registration;

namespace ColorSoft.Web.Controllers
{
    public partial class RegistrationController : AbstractController
    {
        public virtual ActionResult New()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public virtual ActionResult New(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                return null;
            }

            return View(model);
        }
    }
}