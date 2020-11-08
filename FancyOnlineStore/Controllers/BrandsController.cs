using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Models;
using FancyOnlineStore.Models;

namespace FancyOnlineStore.Controllers
{
    [RoutePrefix("Brands")]
    public class BrandsController : BaseController
    {
        public BrandsController(IServices services) : base(services)
        {
        }

        [Route("List")]
        public ActionResult ListBrands()
        {
            ViewBag.Title = "Our partners";
            var brands = Services.Brand.GetBrands();
            var brandsView = AutoMapper.Mapper
                .Map<IEnumerable<BrandDto>, IEnumerable<BrandViewModel>>(brands);
            return View(brandsView);
        }
    }
}