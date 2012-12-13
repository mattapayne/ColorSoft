using System;
using System.Threading;
using System.Web;
using System.Web.Security;
using Autofac;
using ColorSoft.Web.Infrastructure.Authentication;
using ColorSoft.Web.Services;

namespace ColorSoft.Web.Infrastructure
{
    public class CustomAuthenticationModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += (sender, args) => SetupCustomPrincipal(context);
        }

        #endregion

        private void SetupCustomPrincipal(HttpApplication application)
        {
            var containerProvider = application as IContainerAccessProvider;

            if (containerProvider == null)
            {
                throw new ArgumentNullException("HttpApplication must implement IContainerAccessProvider");
            }

            var service = containerProvider.GetContainer().Resolve<IAuthCookieService>();
            HttpCookie formsCookie = application.Request.Cookies[FormsAuthentication.FormsCookieName];
            string userData = formsCookie == null ? String.Empty : FormsAuthentication.Decrypt(formsCookie.Value).Name;
            ColorSoftIdentity identity = service.ConstructIdentity(userData);
            var principal = new ColorSoftPrincipal(identity);
            application.Context.User = principal;
            Thread.CurrentPrincipal = principal;
        }
    }
}