using System.Web;
using System.Web.Optimization;

namespace TaskWeb
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //时间选择CSS, JS
            bundles.Add(new ScriptBundle("~/DatePicker/js").Include(
                "~/Assets/js/bootstrap-datetimepicker.js",
                "~/Assets/js/bootstrap-datetimepicker.zh-CN.js"
                ));

            bundles.Add(new StyleBundle("~/DatePicker/css").Include(
                "~/Assets/css/bootstrap-datetimepicker.css"
                ));

            //通用CSS, JS
            bundles.Add(new ScriptBundle("~/Comm/js").Include(
                "~/Assets/js/jquery-1.10.2.js",
                "~/Assets/js/bootstrap.js",
                "~/Assets/js/headroom.js",
                "~/Assets/js/jQuery.headroom.js",
                "~/Assets/js/template.js",
                "~/Assets/CommJS.js"
                ));

            bundles.Add(new StyleBundle("~/Comm/css").Include(
                "~/Assets/css/bootstrap.css",
                "~/Assets/css/bootstrap-theme.css",
                "~/Assets/css/main.css"
                ));
        }
    }
}