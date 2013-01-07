using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Infrastructure.Authentication;
using ColorSoft.Web.Validation;

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

        protected HttpResponseMessage DeletedResponse()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected HttpResponseMessage UpdatedResponse()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected HttpResponseMessage CreatedResponse(object model)
        {
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }

        protected HttpResponseMessage ExceptionErrorResponse(Exception e)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
        }

        protected HttpResponseMessage ModelStateErrorResponse()
        {
            var modelStateErrors = GetSimpleModelStateErrors();

            return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content =
                        new ObjectContent(typeof(IEnumerable<string>), modelStateErrors,
                                          new JsonMediaTypeFormatter())
                };
        }

        protected void AddModelStateErrors(ApplicationValidationException exception)
        {
            if (exception == null)
            {
                return;
            }

            exception.Errors.ToList().ForEach(e => ModelState.AddModelError(e.PropertyName, e.ErrorMessage));
        }

        protected IEnumerable<string> GetSimpleModelStateErrors()
        {
            if(!ModelState.IsValid)
            {
                return ModelState.Where(ms => ms.Value.Errors.Any()).Where(ms => ms.Key != "model").
                    SelectMany(ms => ms.Value.Errors.Select(e => e.ErrorMessage)).
                    ToList();
            }

            return Enumerable.Empty<string>();
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