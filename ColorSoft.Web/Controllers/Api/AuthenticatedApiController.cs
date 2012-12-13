using System.Web;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Controllers.Api
{
    [Authorize]
    public abstract class AuthenticatedApiController : ApiController
    {
        private readonly IMappingEngine _mappingEngine;

        protected AuthenticatedApiController(
            IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        protected IMappingEngine MappingEngine
        {
            get { return _mappingEngine; }
        }

        protected ColorSoftPrincipal CurrentUser
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.User as ColorSoftPrincipal;
                }

                return null;
            }
        }
    }
}