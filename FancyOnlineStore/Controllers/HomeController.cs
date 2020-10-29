using BusinessLayer;
using System.Web.Mvc;

namespace FancyOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IUserService blContext;

        //public HomeController(IUserService blContext)
        //{
        //    this.blContext = blContext;
        //}

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
            // TODO: Hook up dependency injection to MVC controllers
            return string.Join(", ", new UserService().GetNames());
            //return string.Join(",", blContext.GetNames());
        }
    }
}