using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServices services) : base(services)
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Title = "Contact";
            return View();
        }

        public string GetNames()
        {
            return string.Join(",", Services.User.GetNames());
        }
    }
}