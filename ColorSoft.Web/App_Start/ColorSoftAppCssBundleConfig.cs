using System.Web.Optimization;
using ColorSoft.Web.App_Start;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (ColorSoftAppCssBundleConfig), "RegisterBundles")]

namespace ColorSoft.Web.App_Start
{
    public class ColorSoftAppCssBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new StyleBundle("~/Css/application").Include("~/Content/Css/application.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/Css/dashboard").Include("~/Content/Css/dashboard.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/Css/bootstrap").Include("~/Content/Css/bootstrap.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/Css/angular-ui").Include("~/Content/Css/angular-ui.css"));
        }
    }
}