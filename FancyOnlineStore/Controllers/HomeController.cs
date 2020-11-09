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

        public string GetNames()
        {
            return string.Join(",", Services.User.GetNames());
        }
    }
}