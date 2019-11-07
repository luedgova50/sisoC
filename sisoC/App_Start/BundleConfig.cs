using System.Web;
using System.Web.Optimization;

namespace sisoC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Create bundel for jQueryUI  
            //js  
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                     "~/Content/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui")
                    .Include("~/Content/themes/base/all.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/moment.js",        
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/sisoC.js",
                        "~/Scripts/bootstrap-datetimepicker.js",
                        "~/Scripts/fileupload.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Content/bootstrap-datetimepicker.css",
                        "~/Content/themes/base/all.css",
                        "~/Content/jquery-ui.css"));

        }
    }
}
