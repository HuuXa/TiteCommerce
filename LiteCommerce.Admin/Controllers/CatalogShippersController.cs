using LiteCommerce.BusinessLayers;
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
        public ActionResult Index(int page =1, string searchValue = "")
        {
            var model = new Models.ShipperPaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Shipper_Count(searchValue),
                Data = CatalogBLL.Shipper_List(page, AppSettings.DefaultPageSize, searchValue)
            };
            return View(model);
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