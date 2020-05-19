using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    /// <summary>
    /// hiển thị ds các supplller, các "kiên kết" đến các chức năng liên quan
    /// </summary>  
     [Authorize]
    public class CatalogSuppliersController : Controller
    {
        // GET: CatalogSuppliers
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Input( string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "add new suppliers";
            }
            else
            {
                ViewBag.Title = "edit suppliers";
            }
            return View();
        }
    }
}