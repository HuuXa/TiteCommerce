using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
     [Authorize]
    public class EmplogesController : Controller
    {
        // GET: Emploges
        public ActionResult Index(int page = 1,string searchValue = "")
        {
            var model = new Models.EmployeePaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Employee_Count(searchValue),
                Data = CatalogBLL.Emplogese_List(page, AppSettings.DefaultPageSize, searchValue)
            };
            return View(model);
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "add new Emploges";
            }
            else
            {
                ViewBag.Title = "Edit Emploges";
            }
            return View();
        }
    }
}