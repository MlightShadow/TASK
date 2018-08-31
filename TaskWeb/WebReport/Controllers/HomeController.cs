using System.Web.Mvc;

namespace WebReport.Controllers
{
    public class HomeController : SessionController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}