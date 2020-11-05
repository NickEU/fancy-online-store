using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IServices _services;

        public BrandsController(IServices services)
        {
            _services = services;
        }

        public ActionResult ListBrands()
        {
            return View(_services.Brand.GetNames());
        }
    }
}