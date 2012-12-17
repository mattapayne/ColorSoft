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
                                        Include("~/Scripts/applications/colorsoft/controllers/*.js",
                                                "~/Scripts/applications/colorsoft/services/*.js",
                                                "~/Scripts/applications/colorsoft/colorsoft.js", 
                                                "~/Scripts/applications/colorsoft/directives/*.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/applications/messaging").
                                        Include("~/Scripts/applications/messaging/controllers/*.js",
                                                "~/Scripts/applications/messaging/services/*.js",
                                                "~/Scripts/applications/messaging/messaging.js"));
        }
    }
}