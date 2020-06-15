using LiteCommerce.BussinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        /// <summary>
        /// Profile
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePwd()
        {
            return View();
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(/*Account account */string email = "", string password = "")
        {
     

            if (Request.HttpMethod == "GET")
            {
                return View();
            }
            else
            {
                //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
                // Use input string to calculate MD5 hash
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                string Pass = sb.ToString();
                //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
                // Use input string to calculate MD5 hash

                UserAccount user = UserAccountBLL.Authorize(email, Pass, UserAccountTypes.Employee);
                if (user != null)//đn thành công
                {
                    //ghi nhận phiên đn của user
                    WebUserData userData = new WebUserData()
                    {
                        UserID = user.UserID,
                        FullName = user.FullName,
                        GroupName = user.Roles,
                        LoginTime = DateTime.Now,
                        SessionID = Session.SessionID,
                        ClientIP = Request.UserHostAddress,
                        Photo = user.Photo
                    };


                    FormsAuthentication.SetAuthCookie(userData.ToCookieString(), false);
                    return RedirectToAction("Index", "Dashboard");
                }
                else //đn thành công
                {
                    ModelState.AddModelError("LoginError", "Login fail");
                    ViewBag.Email = email;
                    return View();
                }

            }

        }

        /// <summary>
        /// Forgot Pass
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ForgotPwd()
        {
            return View();
        }
    }
}