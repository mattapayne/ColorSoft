using System.Web.Optimization;
using ColorSoft.Web.App_Start;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (JsApplicationsBundleConfig), "RegisterBundles")]

namespace ColorSoft.Web.App_Start
{
    public class JsApplicationsBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/angular").
                Include("~/scripts/lib/angular.js", 
                "~/scripts/lib/angular-resource.js",
                "~/scripts/lib/angular-ui/angular-ui.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/applications/colorsoft").
                                        Include("~/Scripts/applications/colorsoft/models/*.js",
                                                "~/Scripts/applications/colorsoft/controllers/*.js",
                                                "~/Scripts/applications/colorsoft/services/*.js",
                                                "~/Scripts/applications/colorsoft/colorsoft.js"));
        }
    }
}