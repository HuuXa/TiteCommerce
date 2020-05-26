
using LiteCommerce.BusinessLayers;
using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class CatalogCategoriesController : Controller
    {
        // GET: CatalogCategories
        public ActionResult Index(int page = 1, string searchValue ="")
        {
            var model = new Models.CategoriePaginationResult()
            {
                Page = page,
                PageSize = 30,
                RowCount = CatalogBLL.Categorie_Count(searchValue),
                Data = CatalogBLL.Categorie_List(page, 30, searchValue)
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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