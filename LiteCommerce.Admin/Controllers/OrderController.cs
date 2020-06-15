using LiteCommerce.BussinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize(Roles = WebUserRoles.Saleman)]
    public class OrderController : Controller
    {
        /// <summary>
        /// Quản lý Order
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            var model = new Models.OrderPaginationResult()
            {
                Page = page,
                PageSize = AppSettings.DefaultPageSize,
                RowCount = CatalogBLL.Order_Count(searchValue),
                SearchValue = searchValue,
                Data = CatalogBLL.Order_List(page, AppSettings.DefaultPageSize, searchValue)
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Input(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add new Order";
                Order newOrder = new Order();
                newOrder.OrderID = 0;
                return View(newOrder);
            }
            else
            {
                try
                {
                    ViewBag.Title = "Edit order";
                    Order editOrder = CatalogBLL.Order_Get(Convert.ToInt32(id));
                    if (editOrder == null)
                        return RedirectToAction("Index");
                    return View(editOrder);
                }
                catch (FormatException)
                {
                    return RedirectToAction("Index");
                }
            }

        }

        [HttpPost]
        public ActionResult Input(Order model)
        {
            try
            {
                // Check Value
                //  DB
                if (model.OrderID == 0)
                {
                    int orderID = CatalogBLL.Order_Add(model);
                }
                else
                {
                    bool updateResult = CatalogBLL.Order_Update(model);
                   
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + " : " + ex.StackTrace);
                return View(model);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methods"></param>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string methods = "", int[] orderIDs = null)
        {
            if (orderIDs != null)
            {
                CatalogBLL.Order_Delete(orderIDs);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Tạo mới Order
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}