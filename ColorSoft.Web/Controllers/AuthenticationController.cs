using System.Web.Mvc;
using ColorSoft.Web.Models.Authentication;
using ColorSoft.Web.Services;

namespace ColorSoft.Web.Controllers
{
    public partial class AuthenticationController : AbstractController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public virtual ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_authenticationService.Authenticate(model.Username, model.Password))
                {
                    _authenticationService.SetAuthCookie(model.Username, model.RememberMe);
                    return Redirect(_authenticationService.DefaultUrl);
                }
            }

            return RedirectToAction(MVC.Home.Index().AddRouteValues(new {model.Username, Failed = true}));
        }

        [HttpPost]
        public virtual ActionResult Logout()
        {
            _authenticationService.SignOut();
            return RedirectToAction(MVC.Home.Index());
        }
    }
}