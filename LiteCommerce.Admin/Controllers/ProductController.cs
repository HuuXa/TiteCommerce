using LiteCommerce.BussinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize(Roles = WebUserRoles.DataManage)]
    public class ProductController : Controller
    {
        /// <summary>
        /// Quản lý sản phẩm
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "", string categoryId = "0", string supplierId = "0")
        {
            var model = new Models.ProductPaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Product_Count(searchValue),
                SearchValue = searchValue,
                Category = categoryId,
                Supplier = categoryId,
                Data = CatalogBLL.Product_List(page, AppSettings.DefaultPageSize, searchValue, Convert.ToInt32(categoryId), Convert.ToInt32(supplierId))
            };
            return View(model);
        }

        public ActionResult Input(string id = "")
        {
          
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add new Product";
                Product newProduct = new Product();
                newProduct.ProductID = 0;
                return View(newProduct);
            }
            else
            {
                try
                {
                    ViewBag.Title = "Edit Product";
                    Product editProduct = CatalogBLL.Product_Get(Convert.ToInt32(id));
                    if (editProduct == null)
                        return RedirectToAction("Index");
                    return View(editProduct);
                }
                catch (FormatException)
                {
                    return RedirectToAction("Index");
                }
            }
        }
        [HttpPost]
        public ActionResult Input(Product model)
        {
            try
            {
                // Check Value
                if (string.IsNullOrEmpty(model.ProductName))
                {
                    ModelState.AddModelError("ProductName", "Product Name is required");
                }
                if (string.IsNullOrEmpty(model.QuantityPerUnit))
                {
                    ModelState.AddModelError("QuantityPerUnit", "QuantityPerUnit is required");
                }
                if (string.IsNullOrEmpty(model.UnitPrice.ToString()))
                {
                    ModelState.AddModelError("UnitPrice", "UnitPrice is required");
                }
                if (string.IsNullOrEmpty(model.Descriptions))
                {
                    model.Descriptions = "";
                }
                if (string.IsNullOrEmpty(model.PhotoPath))
                {
                    model.Descriptions = "";
                }

                if (!ModelState.IsValid)
                {
                    // Return True : Valid
                    // Return False : No valid
                    ViewBag.Title = model.ProductID == 0 ? "Add New Product" : "Edit Product";
                    return View(model);
                }

                //  DB
                if (model.ProductID == 0)
                {
                    int ProductID = CatalogBLL.Product_Add(model);
                    return RedirectToAction("Index");

                }
                else
                {
                    bool updateResult = CatalogBLL.Product_Update(model);
                    return RedirectToAction("Index");
                

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + " : " + ex.StackTrace);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(string methods = "", int[] productIDs = null)
        {
            if (productIDs != null)
            {
                CatalogBLL.Product_Delete(productIDs);
            }
            return RedirectToAction("Index");
        }
    }
}