using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using ColorSoft.Web.App_Start;
using ColorSoft.Web.Infrastructure;
using FluentValidation.Mvc;

namespace ColorSoft.Web
{
    public class MvcApplication : HttpApplication, IContainerAccessProvider
    {
        private static IContainer _container;

        #region IContainerAccessProvider Members

        public IContainer GetContainer()
        {
            return _container;
        }

        #endregion

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();
            _container = Bootstrapper.Initialize();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            FilterConfig.RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
        }
    }
}