using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
     [Authorize]
    public class CatalogCustomersController : Controller
    {
        // GET: CatalogCustomers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "add new Customers";
            }
            else
            {
                ViewBag.Title = "Edit Customers";
            }
            return View();
        }
    }
}