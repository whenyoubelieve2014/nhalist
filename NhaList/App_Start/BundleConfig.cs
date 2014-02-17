using System.Web.Optimization;

namespace NhaList
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                //.Include("~/Scripts/angular-loader.js")
                //.Include("~/Scripts/angular-cookies.js")
                //.Include("~/Scripts/angular-animate.js")
                //.Include("~/Scripts/angular-sanitize.js")
                //.Include("~/Scripts/ui-bootstrap-0.10.0.js")
                //.Include("~/Scripts/ui-bootstrap-tpls-0.10.0.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/appRoutes.js")
                .Include("~/Scripts/app.js")
                );
            
            bundles.Add(new ScriptBundle("~/bundles/homeController").Include(
                "~/Scripts/Controllers/home.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/site")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-theme.min.css")
                .Include("~/Content/Site.css")
                );

        }
    }
}