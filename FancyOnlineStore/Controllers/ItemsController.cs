using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Models;
using FancyOnlineStore.Models;
using PagedList;

namespace FancyOnlineStore.Controllers
{
    [RoutePrefix("Items")]
    public class ItemsController : Controller
    {
        private readonly IServices _services;
        private List<ProductDto> _clothesCache;

        public ItemsController(IServices services)
        {
            _services = services;
        }

        [Route("List")]
        public ActionResult ListItems(int? page)
        {
            ViewBag.Title = "Our collection";
            _clothesCache = _clothesCache ?? _services.Product
                .GetProductsWithClothingType(ClothingType.Jacket)
                .OrderByDescending(p => p.ProductName.Length)
                .ThenByDescending(p => p.ProductName)
                .ToList();

            // might need to do some additional steps in the future
            var clothes = _clothesCache;
            var clothesView = AutoMapper.Mapper
                .Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(clothes);

            const int pageSize = 10;
            var pageNum = page ?? 1;
            return View(clothesView.ToPagedList(pageNum, pageSize));
        }
    }
}