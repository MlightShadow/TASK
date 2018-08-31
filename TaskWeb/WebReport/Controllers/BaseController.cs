using System.Web.Mvc;
using WebReport.Models;

namespace WebReport.Controllers
{
    public class BaseController : Controller
    {
        protected CommManager commManager = new CommManager();
    }
}