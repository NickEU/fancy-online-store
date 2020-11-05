using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServices _services;

        public HomeController(IServices services)
        {
            _services = services;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetNames()
        {
            return string.Join(",", _services.User.GetNames());
        }

        public ActionResult ListBrands()
        {
            return View(_services.Brand.GetNames());
        }

        public ActionResult ListItems()
        {
            return View();
        }
    }
}