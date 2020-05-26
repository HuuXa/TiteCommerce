using LiteCommerce.BusinessLayers;
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
        public ActionResult Index( int page= 1, string searchValue ="")
        {
            var model = new Models.SupplierPaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Suppliers_Count(searchValue),
                Data = CatalogBLL.Suppliers_List(page, AppSettings.DefaultPageSize, searchValue),
            };

            //var listOfSuppliers = CatalogBLL.Suppliers_List(page, 10, searchValue);
            //int rowCount = CatalogBLL.SuSuppliers_Count(searchValue);
            //ViewBag.RowCount = rowCount;
            return View(model);
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