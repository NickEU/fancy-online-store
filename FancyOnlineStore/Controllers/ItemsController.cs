using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Models;
using FancyOnlineStore.Models;

namespace FancyOnlineStore.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IServices _services;

        public ItemsController(IServices services)
        {
            _services = services;
        }

        public ActionResult ListItems()
        {
            var products = _services.Product
                .GetProductsWithClothingType(ClothingType.Jacket)
                //TODO: add auto mapping
                .Select(p => new ProductViewModel
                {
                    BrandName = p.BrandName, Type = p.Type
                })
                .ToList();
            return View(products);
        }
    }
}