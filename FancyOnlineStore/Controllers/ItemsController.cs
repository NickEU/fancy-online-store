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

        public ItemsController(IServices services)
        {
            _services = services;
        }

        [Route("List")]
        public ActionResult ListItems(int? page)
        {
            ViewBag.Title = "Our collection";
            var clothes = _services.Product
                .GetProductsWithClothingType(ClothingType.Jacket);
            var clothesView = AutoMapper.Mapper
                .Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(clothes);

            const int pageSize = 3;
            var pageNum = page ?? 1;
            return View(clothesView.ToPagedList(pageNum, pageSize));
        }
    }
}