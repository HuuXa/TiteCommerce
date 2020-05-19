using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
     [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Create()
        {
            return View();
        }
    }
}