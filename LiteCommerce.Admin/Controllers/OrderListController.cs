using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class OrderListController : Controller
    {
        // GET: OrderList
        public ActionResult Index()
        {
            return View();
        }
    }
}