using System.Web;
using System.Web.Optimization;

namespace InventoryWA
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                        "~/admin-lte/js/adminlte.js",
                        "~/admin-lte/plugins/fastclick/fastclick.js",
                        "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-route.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css",
                        "~/Content/site.css",
                        "~/Content/toastr.css",
                        "~/admin-lte/css/AdminLTE.css",
                        "~/admin-lte/Ionicons/css/ionicons.css",
                        "~/admin-lte/css/skins/skin-blue.css",
                        "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"));

            // add controllers for application Angular JS
            bundles.Add(new ScriptBundle("~/bundles/appAngular").Include(
                        "~/Scripts/app/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/appCategories").Include(
                        "~/Scripts/app/Categories/CategorieService.js",
                        "~/Scripts/app/Categories/CategorieDirective.js",
                        "~/Scripts/app/Categories/CategorieController.js"));
        }
    }
}
