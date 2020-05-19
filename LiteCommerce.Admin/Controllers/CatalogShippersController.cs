using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
     [Authorize]
    public class CatalogShippersController : Controller
    {
        // GET: CatalogShippers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add New Shippers";
            }
            else
            {
                ViewBag.Title = "Edit Shippers";
            }
            return View();
        }
    }
}