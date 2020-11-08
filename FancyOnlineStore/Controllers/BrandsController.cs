using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Models;
using FancyOnlineStore.Models;

namespace FancyOnlineStore.Controllers
{
    [RoutePrefix("Brands")]
    public class BrandsController : Controller
    {
        private readonly IServices _services;

        public BrandsController(IServices services)
        {
            _services = services;
        }

        [Route("List")]
        public ActionResult ListBrands()
        {
            ViewBag.Title = "Our partners";
            var brands = _services.Brand.GetBrands();
            var brandsView = AutoMapper.Mapper
                .Map<IEnumerable<BrandDto>, IEnumerable<BrandViewModel>>(brands);
            return View(brandsView);
        }
    }
}