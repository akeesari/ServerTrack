using System.Web.Mvc;

namespace Prodapt.ServerTrack.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("http://localhost:2445/swagger/ui/index");
            //ViewBag.Title = "Home Page";

            //return View();
        }
    }
}
