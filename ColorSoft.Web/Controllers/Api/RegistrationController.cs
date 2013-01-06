using System.Net.Http;
using System.Web.Http;
using ColorSoft.Web.Models.Api.Registration;

namespace ColorSoft.Web.Controllers.Api
{
    public partial class RegistrationController : ApiController
    {
        public virtual HttpResponseMessage Create(RegistrationViewModel model)
        {
            return null;
        }
    }
}
