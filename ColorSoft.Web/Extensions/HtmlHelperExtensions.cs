using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace ColorSoft.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString ConvertToJson(this HtmlHelper helper, object o)
        {
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(o);
            return MvcHtmlString.Create(json);
        }

        public static IHtmlString RenderColorSoftApplication(this HtmlHelper helper)
        {
            return Scripts.Render("~/scripts/applications/colorsoft");
        }

        public static IHtmlString RenderTemplateUrls(this HtmlHelper helper)
        {
            var url = new UrlHelper(helper.ViewContext.RequestContext);

            var templateUrls = new
                {
                    ContactUrl = url.Action(MVC.Templates.Contact()),
                    AboutUrl = url.Action(MVC.Templates.About()),
                    DashboardUrl = url.Action(MVC.Templates.Dashboard()),
                    HomeUrl = url.Action(MVC.Templates.Home()),
                    RegisterUrl = url.Action(MVC.Templates.Register()),
                    ListUsersUrl = url.Action(MVC.Templates.UsersList()),
                    ListMessagesUrl = url.Action(MVC.Templates.MessagesList())
                };

            var script = @"<script type='text/javascript'>
                        angular.module('colorSoft').constant('TemplateUrls', <INSERT_URLS>);
                    </script>".Replace("<INSERT_URLS>", CreateJavascriptHash(templateUrls));

            return MvcHtmlString.Create(script);
        }

        public static IHtmlString RenderApplicationUrls(this HtmlHelper helper)
        {
            var url = new UrlHelper(helper.ViewContext.RequestContext);

            var applicationUrls = new
            {
                RegisterUrl = url.Action(MVC.Registration.Create()),
                LoginUrl = url.Action(MVC.Authentication.Login()),
                LogoutUrl = url.Action(MVC.Authentication.Logout()),
                LoginCheckUrl = url.Action(MVC.Authentication.LoginCheck())
            };

            var script = @"<script type='text/javascript'>
                        angular.module('colorSoft').constant('ApplicationUrls', <INSERT_URLS>);
                    </script>".Replace("<INSERT_URLS>", CreateJavascriptHash(applicationUrls));

            return MvcHtmlString.Create(script);
        }

        private static string CreateJavascriptHash(object urls)
        {
            if(urls == null)
            {
                return "{ }";
            }

            var sb = new StringBuilder("{ ");
            var dict = new RouteValueDictionary(urls);

            foreach(var kvp in dict)
            {
                sb.AppendFormat("{0}: '{1}', ", kvp.Key, kvp.Value);
                sb.AppendLine();
            }

            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine(" }");

            return sb.ToString();
        }
    }
}