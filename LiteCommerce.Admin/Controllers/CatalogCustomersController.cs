using LiteCommerce.BusinessLayers;
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

        /// <summary>
        /// trang hiển thị các customer , với các link chức năng liên quan  
        /// </summary>
        /// <param name="page"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            var model = new Models.CustomerPaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Customer_Count(searchValue),
                Data = CatalogBLL.Customer_List(page, AppSettings.DefaultPageSize, searchValue)
            };
            return View(model);
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