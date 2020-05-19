using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class CatalogCategoriesController : Controller
    {
        // GET: CatalogCategories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add New Categories";
            }
            else
            {
                ViewBag.Title = "Edit Categories";
            }
            return View();
        }
    }
}