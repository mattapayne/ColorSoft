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
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/knockout").
                Include("~/scripts/lib/knockout-2.2.0.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/sammy").
                                        Include("~/scripts/lib/sammy-0.7.1.js", "~/scripts/lib/sammy.template.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/applications/colorsoft").
                                        Include("~/Scripts/applications/colorsoft/colorsoft.js",
                                                "~/Scripts/applications/colorsoft/dataaccess/database.js",
                                                "~/Scripts/applications/colorsoft/models/*.js",
                                                "~/Scripts/applications/colorsoft/view_models/*.js"));
        }
    }
}