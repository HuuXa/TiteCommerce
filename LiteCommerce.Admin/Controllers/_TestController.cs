using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class _TestController : Controller
    {
        
        [Authorize/*(Roles = WebUserRoles.STAFF)*/]// kiểm tra quyền đăng nhập
        ////
        public ActionResult CheckAuth()
        {
            return Json(User.GetUserData(), JsonRequestBehavior.AllowGet);
        }
        // GET: _Test
        public ActionResult Index()
        {
            return View();
        }
    }
}