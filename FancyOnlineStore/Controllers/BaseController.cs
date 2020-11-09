using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DAL.Models;
using FancyOnlineStore.Models;

namespace FancyOnlineStore.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServices Services;
        public BaseController(IServices services)
        {
            Services = services;
            if (ProductPossibleValues.Brands is null)
            {
                var brands = Services.Brand.GetBrands();
                var brandsView = AutoMapper.Mapper
                    .Map<IEnumerable<BrandDto>, IReadOnlyCollection<BrandViewModel>>(brands);
                ProductPossibleValues.Brands = brandsView;
            }
        }
    }
}