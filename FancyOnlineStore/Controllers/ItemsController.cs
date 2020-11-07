using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Models;
using FancyOnlineStore.Models;
using PagedList;

namespace FancyOnlineStore.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IServices _services;

        public ItemsController(IServices services)
        {
            _services = services;
        }

        public ActionResult List(int? page)
        {
            ViewBag.Title = "Our collection";
            var products = _services.Product
                .GetProductsWithClothingType(ClothingType.Jacket)
                //TODO: add auto mapping
                .Select(p => new ProductViewModel
                {
                    BrandName = p.BrandName, Type = p.Type
                })
                .ToList();
            const int pageSize = 3;
            var pageNum = page ?? 1;
            return View(products.ToPagedList(pageNum, pageSize));
        }
    }
}