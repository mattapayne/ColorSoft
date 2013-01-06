using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ColorSoft.Web.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ModelRequiredAttribute : ActionFilterAttribute
    {
        private const string DefaultModelKey = "model";
        private string _modelParameterName;

        public string ModelParameterName
        {
            get { return String.IsNullOrEmpty(_modelParameterName) ? DefaultModelKey : _modelParameterName; }
            set { _modelParameterName = value; }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(!actionContext.ActionArguments.ContainsKey(ModelParameterName))
            {
                actionContext.Response = GetFailedMessage(actionContext);
            }

            object model;

            if(!actionContext.ActionArguments.TryGetValue(ModelParameterName, out model))
            {
                actionContext.Response = GetFailedMessage(actionContext);
            }
        }

        private HttpResponseMessage GetFailedMessage(HttpActionContext actionContext)
        {
            return actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                                                   new ArgumentNullException(
                                                                                       ModelParameterName));
        }
    }
}