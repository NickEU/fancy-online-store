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
    public class ItemsController : BaseController
    {
        public ItemsController(IServices services) : base(services)
        {
        }

        [Route("List")]
        public ActionResult ListItems(int? page)
        {
            ViewBag.Title = "Our collection";
            // not the greatest solution in the world
            var clothes = Services.Product
                .GetProductsWithClothingType(ClothingType.Shirt)
                .OrderByDescending(p => p.ProductName.Length)
                .ThenByDescending(p => p.ProductName)
                .ToList();
            var clothesView = AutoMapper.Mapper
                .Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(clothes);

            const int pageSize = 10;
            var pageNum = page ?? 1;
            // TODO: implement server-side pagination, using SQL stored procedure??
            return View(clothesView.ToPagedList(pageNum, pageSize));
        }

        [Route("Add")]
        public ActionResult AddItem()
        {
            return View();
        }

        [Route("Add")]
        [HttpPost]
        public ActionResult AddItem(ProductViewModel product)
        {
            if (!ModelState.IsValid) return View();

            product.BrandId = Services.Brand.GetBrandIdFromName(product.BrandName);
            var productDto = AutoMapper.Mapper.Map<ProductViewModel, ProductDto>(product);

            Services.Product.AddProduct(productDto);
            //TODO: make sure the product was added to the DB, placeholder for now
            ViewBag.Success = true;

            return View();
        }

        [Route("Remove")]
        [HttpPost]
        public ActionResult RemoveItem(ProductViewModel product)
        {
            var productDto = AutoMapper.Mapper.Map<ProductViewModel, ProductDto>(product);
            Services.Product.RemoveProduct(productDto);
            return RedirectToAction("ListItems");
        }
    }
}