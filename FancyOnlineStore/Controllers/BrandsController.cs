using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IServices _services;

        public BrandsController(IServices services)
        {
            _services = services;
        }

        public ActionResult List()
        {
            ViewBag.Title = "Our partners";
            return View(_services.Brand.GetNames());
        }
    }
}