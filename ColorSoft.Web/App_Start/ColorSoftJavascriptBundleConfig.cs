using System.Web.Optimization;
using ColorSoft.Web.App_Start;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (ColorSoftJavascriptBundleConfig), "RegisterBundles")]

namespace ColorSoft.Web.App_Start
{
    public class ColorSoftJavascriptBundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/jQuery").Include("~/Scripts/lib/jquery-1.8.2.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/jQueryUI").Include("~/Scripts/lib/jquery-ui-1.9.0.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/jQueryValidate").Include("~/Scripts/lib/jquery.validate.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/jQueryValidateUnobtrusive").Include("~/Scripts/lib/jquery.validate.unobtrusive.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include("~/Scripts/lib/bootstrap.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/underscore").Include("~/Scripts/lib/underscore.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/common").Include("~/Scripts/common.js"));
        }
    }
}