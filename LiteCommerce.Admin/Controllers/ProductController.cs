using LiteCommerce.BussinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
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
                RowCount = CatalogBLL.Product_Count(searchValue, categoryId,supplierId),
                SearchValue = searchValue,
                Category = categoryId,
                Supplier = categoryId,
                Data = CatalogBLL.Product_List(page, AppSettings.DefaultPageSize, searchValue, Convert.ToInt32(categoryId), Convert.ToInt32(supplierId))
            };
            //ViewData["Category"] = CatalogBLL.Category_List(1, CatalogBLL.Category_Count(""), "");
            //ViewData["Supplier"] = CatalogBLL.Supplier_List(1, CatalogBLL.Supplier_Count(""), "");
            return View(model);
        }
        public ActionResult Detail(string id = "")
        {
            if (!String.IsNullOrEmpty(id))
            {
                Product model = CatalogBLL.Product_Get(Convert.ToInt32(id));
                if (model == null)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewData["Attribute"] = CatalogBLL.ProductAttribute_List(model.ProductID);
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }
        public ActionResult Input(string id = "")
        {
            if (String.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add Product";
                var newProduct = new Product();
                newProduct.ProductID = 0;
                return View(newProduct);
            }
            else
            {
                ViewBag.Title = "Edit Product";
                var editProduct = CatalogBLL.Product_Get(Convert.ToInt32(id));
                if (editProduct == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Attribute"] = CatalogBLL.ProductAttribute_List(editProduct.ProductID);
                    return View(editProduct);
                }
            }
        }
        [HttpPost]
        public ActionResult Input(Product model, HttpPostedFileBase fileimg)
        {
            //if (model.Descriptions == null)
            //{
            //    model.Descriptions = "";
            //}
            //if (fileimg != null)
            //{
            //    string get = DateTime.Now.ToString("ddMMyyyhhmmss");
            //    string fileExtension = Path.GetExtension(fileimg.FileName);
            //    string fileName = get + fileExtension;
            //    string path = Path.Combine(Server.MapPath("~/Images"), fileName);
            //    model.PhotoPath = fileName;
            //    fileimg.SaveAs(path);
            //}
            //if (model.ProductID == 0)
            //{
            //    if (fileimg == null)
            //    {
            //         model.PhotoPath = "";
            //    }
            //    else
            //    {
            //        int productID = CatalogBLL.Product_Add(model);
            //        ///return Content( productID.ToString());
            //        TempData["productID"] = productID;
            //        return RedirectToAction("Add_Attr");
            //    }

            //}
            //else
            //{

            //    var getProduct = CatalogBLL.Product_Get(model.ProductID);
            //    if (fileimg == null)
            //    {
            //        model.PhotoPath = getProduct.PhotoPath;
            //    }

            //    bool updateResult = CatalogBLL.Product_Update(model);
            //    return RedirectToAction("Index");
            //}


            if (string.IsNullOrEmpty(model.ProductName))
                ModelState.AddModelError("ProductName", "Product Name required");
            if (string.IsNullOrEmpty(model.QuantityPerUnit))
                model.QuantityPerUnit = "";
            if (string.IsNullOrEmpty(model.UnitPrice.ToString()))
                model.UnitPrice = 0;
            if (string.IsNullOrEmpty(model.CategoryID.ToString()))
                model.CategoryID = 0;
            if (string.IsNullOrEmpty(model.SupplierID.ToString()))
                model.SupplierID = 0;
            var type = "Add";
            if (model.ProductID != 0)
                type = "Edit";
            var fileName = "";
            var typeFile = "";
            if (fileimg != null)
            {
                //kiểm tra loại của file
                fileName = Path.GetFileName(fileimg.FileName);
                typeFile = fileName.Substring(fileName.IndexOf('.'));
                if (typeFile != ".png" && typeFile != ".jpg" && typeFile != ".jpeg" && typeFile != ".PNG" && typeFile != ".JPG" && typeFile != ".JPEG")
                {
                    ModelState.AddModelError("pathFile", "File is not image");
                    return View(model);
                }
            }
            else
            {
                model.PhotoPath = "";
            }
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                if (model.ProductID == 0)
                {
                    //var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    //file.SaveAs(path);
                    int supplierId = CatalogBLL.Product_Add(model, fileimg);
                    return RedirectToAction("Index");
                }
                else
                {
                    //bool updateResult = CatalogBLL.Products_Update(model, file);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ": " + ex.StackTrace);
                return View();
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
        public ActionResult Add_Attr(ProductAttribute model)
        {
            if (model.AttributeID == 0)
            {
                var addAttr = CatalogBLL.ProductAttribute_Add(model);
                return RedirectToAction("Input", "Product", new { id = model.ProductID });

                //return Content(addAttr.ToString());
            }
            else
            {
                var editAttr = CatalogBLL.ProductAttribute_Update(model);
                return RedirectToAction("Input", "Product", new { id = model.ProductID });

                //return Content(editAttr.ToString());
            }
        }
        [HttpPost]
        public ActionResult Delete_Attr(int[] attributes, string productID)
        {
            if (attributes != null)
            {
                var deleteAttr = CatalogBLL.ProductAttribute_Delete(attributes);
            }
            return RedirectToAction("Input", "Product", new { id = Convert.ToInt32(productID) });
        }
    }
}