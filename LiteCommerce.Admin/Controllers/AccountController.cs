using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InputProfile()
        {
            return View();
        }
        public ActionResult ChangePwd()
        {
            return View();
        }
        public ActionResult SignOut()
        {
            Session.Abandon();
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("logIn", "Account");
        }
        [AllowAnonymous]
        public ActionResult Login(string email = "", string password = "")
        {
            if (Request.HttpMethod == "GET")
            {
                return View();
            }
            else
            {
                //TODO: Kiểm tra thông tin đăng nhập qua CSDL
                if (email == "admin@abc.com" && password == "admin")
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(email, false);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                    ViewBag.Email = email;
                    return View();
                }
            }
        }

    }
}