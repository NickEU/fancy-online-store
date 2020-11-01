using BusinessLayer;
using System.Web.Mvc;

namespace FancyOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;

        public HomeController(IUserService userService, IProductService productService)
        {
            this.userService = userService;
            this.productService = productService;
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
            return string.Join(",", userService.GetNames());
        }

        public ActionResult ListBrands()
        {
            return View(productService.GetAllBrands());
        }
    }
}