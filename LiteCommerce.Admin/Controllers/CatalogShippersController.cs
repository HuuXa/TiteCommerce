using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
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
                Data = CatalogBLL.Shipper_List(page, AppSettings.DefaultPageSize, searchValue),
                SearchValue = searchValue,
            };
            return View(model);
        }

        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "add Shipper";
                Shipper newShipper = new Shipper();
                newShipper.ShipperID = 0;
                return View(newShipper);
            }
            else
            {
                ViewBag.Title = "edit Shipper";
                Shipper editShipper = CatalogBLL.Shipper_Get(Convert.ToInt32(id));
                if (editShipper == null)
                {
                    return RedirectToAction("Index");
                }
                return View(editShipper);
            }
        }
    }
}