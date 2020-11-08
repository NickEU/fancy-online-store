using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interfaces;

namespace FancyOnlineStore.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServices Services;
        public BaseController(IServices services)
        {
            Services = services;
        }
    }
}