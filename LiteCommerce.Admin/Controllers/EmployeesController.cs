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
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index(int page = 1,string searchValue = "")
        {
            var model = new Models.EmployeePaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Employee_Count(searchValue),
                Data = CatalogBLL.Employee_List(page, AppSettings.DefaultPageSize, searchValue),
                SearchValue = searchValue,
            };
            return View(model);
        }
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "add Employee";
                Employee newEmployee = new Employee();
                newEmployee.EmployeeID = 0;
                return View(newEmployee);
            }
            else
            {
                ViewBag.Title = "edit Employee";
                Employee editEmployee =  CatalogBLL.Employee_Get(Convert.ToInt32(id));
                if (editEmployee == null)
                {
                    return RedirectToAction("Index");
                }
                return View(editEmployee);
            }
        }
    }
}