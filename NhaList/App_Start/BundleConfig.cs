using System.Web.Optimization;

namespace NhaList
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //    "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.unobtrusive*",
            //    "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //    "~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/Filters/*.js")
                //.Include("~/Scripts/Services/*.js")
                //.Include("~/Scripts/Controllers/search.js")
                //.Include("~/Scripts/Controllers/*.js")
                //.Include("~/Scripts/appRoutes.js")
                //.Include("~/Scripts/app.js")
                .Include("~/Scripts/*.js")
                );

            bundles.Add(new StyleBundle("~/Content/site")
                .Include("~/Content/Site.css")
                );
        }
    }
}