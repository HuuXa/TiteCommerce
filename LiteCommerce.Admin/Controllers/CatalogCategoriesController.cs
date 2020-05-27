
using LiteCommerce.BusinessLayers;
using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SqlServer;
using LiteCommerce.DomainModels;
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
                Data = CatalogBLL.Categorie_List(page, 30, searchValue),
                SearchValue = searchValue,
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
                ViewBag.Title = "Add new Categorie";
                Categorie newCategorie = new Categorie();
                newCategorie.CategoryID = 0;
                return View(newCategorie);
            }
            else
            {
                ViewBag.Title = "Edit Categorie";
                Categorie editCategorie = CatalogBLL.Categorie_Get(Convert.ToInt32(id));
                if (editCategorie == null)
                    return RedirectToAction("Index");
                return View(editCategorie);
            }
        }
    }
}