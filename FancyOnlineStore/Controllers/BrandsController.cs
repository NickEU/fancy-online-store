using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    [RoutePrefix("Brands")]
    public class BrandsController : Controller
    {
        private readonly IServices _services;

        public BrandsController(IServices services)
        {
            _services = services;
        }

        [Route("List")]
        public ActionResult ListBrands()
        {
            ViewBag.Title = "Our partners";
            return View(_services.Brand.GetNames());
        }
    }
}