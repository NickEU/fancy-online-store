using System;
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
            //TODO: Implement filtering and ordering by different columns
            var clothes = Services.Product
                .GetProductsWithClothingType(ClothingType.Shirt)
                .OrderByDescending(p => p.ProductName.Length)
                .ThenByDescending(p => p.ProductName)
                .ToList();
            var clothesView = AutoMapper.Mapper
                .Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(clothes);

            const int pageSize = 10;
            var pageNum = page ?? 1;
            // TODO: This fixes issues with pagination when deleting all the elements
            // TODO: on the last page. Look for a better solution since this one is a hack.
            var maxPageNum = (int) Math.Ceiling(1.0 * clothesView.Count() / pageSize);
            pageNum = Math.Min(pageNum, maxPageNum);
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
            var urlPieces = Request.UrlReferrer?
                .ToString()
                .Split("page=".ToCharArray());
            // defensive programming ftw ( not really :/ )
            var pageNumPotential = urlPieces is null ? "1" : urlPieces.Last();
            var isInteger = int.TryParse(pageNumPotential, out var pageNum);
            var routeVal = new {page = isInteger ? pageNum : 1};

            return RedirectToAction("ListItems", routeVal);
        }
    }
}