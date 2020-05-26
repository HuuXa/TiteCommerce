using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
     [Authorize]
    public class CatalogProductController : Controller
    {
        // GET: CatalogProduct
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "add new Product";
            }
            else
            {
                ViewBag.Title = "Edit Product";
            }
            return View();
        }
    }
}