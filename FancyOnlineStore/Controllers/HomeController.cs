using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public HomeController(IUserService userService, IProductService productService)
        {
            this._userService = userService;
            this._productService = productService;
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
            return string.Join(",", _userService.GetNames());
        }

        public ActionResult ListBrands()
        {
            return View(_productService.GetAllBrands());
        }
    }
}