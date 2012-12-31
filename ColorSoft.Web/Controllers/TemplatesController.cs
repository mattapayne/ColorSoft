using System.Web.Mvc;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Controllers
{
    public partial class TemplatesController : Controller
    {
        [Authorize]
        public virtual ActionResult UsersList()
        {
            return PartialView(MVC.Templates.Views._UsersList);
        }

        [Authorize]
        public virtual ActionResult ColorMatches()
        {
            return PartialView(MVC.Templates.Views._ColorMatchesList);
        }

        [Authorize(Roles = Role.ColorSoftAdministrator)]
        public virtual ActionResult MessagesList()
        {
            return PartialView(MVC.Templates.Views._MessagesList);
        }

        [Authorize]
        public virtual ActionResult ProductsList()
        {
            return PartialView(MVC.Templates.Views._ProductsList);
        }

        [Authorize(Roles = Role.ColorSoftAdministrator)]
        public virtual ActionResult OrganizationsList()
        {
            return PartialView(MVC.Templates.Views._OrganizationsList);
        }

        public virtual ActionResult Login()
        {
            return PartialView(MVC.Templates.Views._Login);
        }

        public virtual ActionResult Register()
        {
            return PartialView(MVC.Templates.Views._Register);
        }

        public virtual ActionResult Home()
        {
            return PartialView(MVC.Templates.Views._Home);
        }

        public virtual ActionResult About()
        {
            return PartialView(MVC.Templates.Views._About);
        }

        public virtual ActionResult Contact()
        {
            return PartialView(MVC.Templates.Views._Contact);
        }

        [Authorize]
        public virtual ActionResult Dashboard()
        {
            return PartialView(MVC.Templates.Views._Dashboard);
        }
    }
}
