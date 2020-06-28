using LiteCommerce.BussinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Quản lý Employeee
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "", string country = "")
        {
            var model = new Models.EmployeePaginationResult()
            {
                Page = page,
                PageSize = 3,
                RowCount = CatalogBLL.Employee_Count(searchValue, country),
                SearchValue = searchValue,
                Country = country,
                Data = CatalogBLL.Employee_List(page, 3, searchValue, country)
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Input(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add new Employee";
                Employee newEmployee = new Employee();
                newEmployee.EmployeeID = 0;
                return View(newEmployee);
            }
            else
            {
                try
                {
                    ViewBag.Title = "Edit Employee";
                    Employee editEmployee = CatalogBLL.Employee_Get(Convert.ToInt32(id));
                    if (editEmployee == null)
                        return RedirectToAction("Index");
                    return View(editEmployee);
                }
                catch (FormatException)
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Input(Employee model, HttpPostedFileBase PhotoPath, string PhotoPathDraft)
        {
            try
            {
                // Check Value
                if (string.IsNullOrEmpty(model.LastName))
                {
                    ModelState.AddModelError("LastName", "LastName is required");
                }
                if (string.IsNullOrEmpty(model.FirstName))
                {
                    ModelState.AddModelError("FirstName", "FirstName is required");
                }
                if (string.IsNullOrEmpty(model.Title))
                {
                    ModelState.AddModelError("Title", "Title is required");
                }
                if (string.IsNullOrEmpty(model.LastName))
                {
                    ModelState.AddModelError("LastName", "LastName is required");
                }
                if (string.IsNullOrEmpty(model.Email))
                {
                    ModelState.AddModelError("Email", "Email is required");
                }

                // Kiem tra email tồn tại khi thêm mới
                if (!HumanResourceBLL.Employee_CheckEmail(model.Email , ""))
                {
                    ModelState.AddModelError("Email", "Email is exist");
                }

                if (string.IsNullOrEmpty(model.BirthDate.ToString()))
                {
                    ModelState.AddModelError("BirthDate", "BirthDate is required");
                }

                if (string.IsNullOrEmpty(model.HireDate.ToString()))
                {
                    ModelState.AddModelError("HireDate", "HireDate is required");
                }
                if (string.IsNullOrEmpty(model.Email))
                {
                    ModelState.AddModelError("Email", "Email is required");
                }

                if (string.IsNullOrEmpty(model.Address))
                {
                    model.Address = "";
                }
                if (string.IsNullOrEmpty(model.City))
                {
                    model.City = "";
                }
                if (string.IsNullOrEmpty(model.Country))
                {
                    ModelState.AddModelError("Country", "Country is required");
                }
                if (string.IsNullOrEmpty(model.HomePhone))
                {
                    model.HomePhone = "";
                }
                if (string.IsNullOrEmpty(model.Notes))
                {
                    model.Notes = "";
                }
                if (string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("Password", "Password is required");
                }
                
                if (!ModelState.IsValid)
                {
                    ViewBag.Title = model.EmployeeID == 0 ? "Add New Employee" : "Edit Employee";
                    return View(model);
                }

                // Upload file
                //TODO :upload image
                if (PhotoPath != null)
                {
                    string FileName = $"{DateTime.Now.Ticks}{Path.GetExtension(PhotoPath.FileName)}";
                    string path = Path.Combine(Server.MapPath("~/Images"), FileName);
                    PhotoPath.SaveAs(path);
                    model.PhotoPath = FileName;
                }

                if (model.EmployeeID == 0)
                {
                    int employeeID = CatalogBLL.Employee_Add(model);
                }
                else
                {
                    bool updateEmployee = CatalogBLL.Employee_Update(model);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + " : " + ex.StackTrace);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(string methods = "", int[] employeeIDs = null)
        {
            if (employeeIDs != null)
            {
                CatalogBLL.Employee_Delete(employeeIDs);
            }
            return RedirectToAction("Index");
        }
    }
}