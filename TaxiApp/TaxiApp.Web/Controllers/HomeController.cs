using System.Web.Mvc;

namespace TaxiApp.Web.Controllers
{
    public class HomeController : TaxiAppControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}