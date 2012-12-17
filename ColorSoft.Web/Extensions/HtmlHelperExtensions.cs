using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace ColorSoft.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString RenderColorSoftApplication(this HtmlHelper helper)
        {
            return Scripts.Render("~/scripts/applications/colorsoft");
        }

        public static IHtmlString RenderMessagingApplication(this HtmlHelper helper)
        {
            return Scripts.Render("~/scripts/applications/messaging");
        }

        public static IHtmlString CommonJsSetup(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"
                    <script type='text/javascript'>
                        window.ColorSoft = window.ColorSoft || {};
                        window.ColorSoft.TopNavigation = window.ColorSoft.TopNavigation || {};
                        window.ColorSoft.TopNavigation.SelectedMenuItem = '<SELECTED_NAVIGATION_ITEM>';
                    </script>".Replace("<SELECTED_NAVIGATION_ITEM>", helper.ViewBag.SelectedNavigationItem));
        }
    }
}