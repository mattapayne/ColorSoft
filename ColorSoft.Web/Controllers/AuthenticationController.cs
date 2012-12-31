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

        [HttpGet]
        public virtual ActionResult LoginCheck()
        {
            return Request.IsAuthenticated
                       ? Json(new {LoggedIn = true, Username = CurrentUser.Identity.Name},
                              JsonRequestBehavior.AllowGet)
                       : Json(new {LoggedIn = false}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_authenticationService.Authenticate(model.Username, model.Password))
                {
                    _authenticationService.SetAuthCookie(model.Username, model.RememberMe);
                    return Json(new {model.Username, LoggedIn = true});
                }
            }

            return
                Json(
                    new
                        {
                            LoggedIn = false,
                            Errors = new[] {"Log in failed. Please check your username and password and try again."}
                        });
        }

        [HttpPost]
        public virtual JsonResult Logout()
        {
            _authenticationService.SignOut();
            return Json(new {Success = true});
        }
    }
}