using BusinessLayer;
using System.Web.Mvc;

namespace FancyOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userContext;
        private readonly IProductService productContext;

        public HomeController(IUserService userContext, IProductService productContext)
        {
            this.userContext = userContext;
            this.productContext = productContext;
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
            return string.Join(",", userContext.GetNames());
        }

        public ActionResult ListBrands()
        {
            return View(productContext.GetAllBrands());
        }
    }
}