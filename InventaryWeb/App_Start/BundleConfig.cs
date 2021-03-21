using System.Web;
using System.Web.Optimization;

namespace InventaryWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-{version}.intellisense.js",
                        "~/Scripts/DataTables/media/js/jquery.dataTables.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Inventary/vendor/jquery/jquery.min.js",
                      "~/Content/Inventary/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Content/Inventary/vendor/jquery-easing/jquery.easing.min.js",
                      "~/Content/Inventary/vendor/magnific-popup/jquery.magnific-popup.min.js",
                      "~/Content/Inventary/js/creative.min.js",
                      "~/Scripts/DataTables/media/js/jquery.dataTables.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Inventary/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/Inventary/vendor/magnific-popup/magnific-popup.css",
                      "~/Content/Inventary/css/creative.min.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/DataTables/media/css/jquery.dataTables.min.css"));
        }


    }
}
