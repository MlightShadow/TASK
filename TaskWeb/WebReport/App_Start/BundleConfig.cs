using System.Web.Optimization;

namespace WebReport
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/base/css").Include(
                "~/Assets/Hplus/css/bootstrap.min.css",
                "~/Assets/Hplus/css/font-awesome.min.css",
                "~/Assets/Hplus/css/animate.min.css",
                "~/Assets/Hplus/css/style.min.css"));

            bundles.Add(new ScriptBundle("~/base/js").Include(
                "~/Assets/Hplus/js/jquery-2.1.1.min.js",
                "~/Assets/Hplus/js/bootstrap.min.js",
                "~/Assets/Hplus/js/plugins/metisMenu/jquery.metisMenu.js",
                "~/Assets/Hplus/js/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/Assets/Hplus/js/plugins/layer/layer.min.js",
                "~/Assets/Hplus/js/hplus.min.js",
                "~/Assets/Hplus/js/contabs.min.js",
                "~/Assets/Hplus/js/plugins/pace/pace.min.js",
                "~/Assets/Hplus/js/content.js",
                "~/Assets/Custom/js/JSComm.js"));

            bundles.Add(new ScriptBundle("~/treeView/js").Include(
                "~/Assets/treeView/js/bootstrap-treeview.js"));

            bundles.Add(new StyleBundle("~/treeView/css").Include(
                "~/Assets/treeView/js/bootstrap-treeview.min.css"));

            bundles.Add(new ScriptBundle("~/bootstrapTable/js").Include(
                "~/Assets/bootstrapTable/js/bootstrap-editable.js",
                "~/Assets/bootstrapTable/js/bootstrap-table.js",
                "~/Assets/bootstrapTable/js/bootstrap-table-zh-CN.js",
                "~/Assets/bootstrapTable/js/bootstrap-table-editable.js",
                "~/Assets/tableExport/tableExport.min.js"
                ));

            bundles.Add(new StyleBundle("~/bootstrapTable/css").Include(
                "~/Assets/bootstrapTable/css/bootstrap-editable.css",
                "~/Assets/bootstrapTable/css/bootstrap-table.css"));

            bundles.Add(new ScriptBundle("~/datetimePicker/js").Include(
                "~/Assets/datetimePicker/js/bootstrap-datetimepicker.js",
                "~/Assets/datetimePicker/js/bootstrap-datetimepicker.zh-CN.js"));

            bundles.Add(new StyleBundle("~/datetimePicker/css").Include(
                "~/Assets/datetimePicker/css/bootstrap-datetimepicker.css"));
        }
    }
}
