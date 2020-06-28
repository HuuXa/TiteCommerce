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
using System.IO;

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
            WebUserData userData = User.GetUserData();
            Employee data = UserAccountBLL.GetProfile(userData.UserID);
            return View(data);
        }

        [HttpGet]
        public ActionResult EditAccount(string id)
        {
            WebUserData userData = User.GetUserData();
            id = userData.UserID;
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Title = "Add new Employee";
                Employee newEmployee = new Employee();
                newEmployee.EmployeeID = 0;
                return View(newEmployee);
            }
            else
            {
                try
                {
                    ViewBag.Title = "Edit Employee";
                    Employee editEmployee = CatalogBLL.Employee_Get(Convert.ToInt32(id));
                    if (editEmployee == null)
                        return RedirectToAction("Index");
                    return View(editEmployee);
                }
                catch (FormatException)
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult EditAccount(Employee model, HttpPostedFileBase fileImage = null)
        {
            if (fileImage != null)
            {
                string get = DateTime.Now.ToString("ddMMyyyhhmmss");
                string fileExtension = Path.GetExtension(fileImage.FileName);
                string fileName = get + fileExtension;
                string path = Path.Combine(Server.MapPath("~/Images"), fileName);
                model.PhotoPath = fileName;
                fileImage.SaveAs(path);
            }
            if (fileImage == null)
            {
                var getEmployee = HumanResourceBLL.Employee_Get(model.EmployeeID);
                model.PhotoPath = getEmployee.PhotoPath;
            }

            bool updateResult = UserAccountBLL.UpdateProfile(model);
            return RedirectToAction("Index");
        }
           [HttpGet]
        public ActionResult ChangePwd()
        {
            return View();
        }
        /// <summary>
        /// Thay đổi mật khẩu
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePwd(string email, string oldpass, string newpass, string repeatpass)
        {
            if (!UserAccountBLL.Check_Pass(email, EncodeMD5.GetMD5(oldpass)))
            {
                ModelState.AddModelError("errorPass", "Sai mật khẩu");
            }
            if (String.Equals(EncodeMD5.GetMD5(newpass), EncodeMD5.GetMD5(repeatpass)) == false)
            {
                ModelState.AddModelError("newPass", "Mật khẩu mới và nhập lại mật khẩu không khớp");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.oldPass = oldpass;
                ViewBag.newPass = newpass;
                ViewBag.repeatPass = repeatpass;
                return View();
            }
            else
            {
                bool rs = UserAccountBLL.Change_Pass(email, EncodeMD5.GetMD5(newpass));
                return RedirectToAction("Index", "Dashboard");
            }
            //return Content("OK");
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
                        Photo = user.Photo,
                        Title = user.Title,
                        LastName = user.LastName,
                        FirstName = user.FirstName,
                        BirthDate = user.BirthDate,
                        Address = user.Address,
                        City = user.City,
                        Country = user.Country,
                        HomePhone = user.HomePhone,
                        Password = user.Password,
                        Email = user.Email
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
        public ActionResult ForgotPwd(string email ="")
        {
            if (email == "")
            {
                return View();
            }
            if (UserAccountBLL.CheckEmail(email, "Add"))
            {
                ModelState.AddModelError("", "Email is not exist");
                return View();
            }
            ModelState.AddModelError("", "Check your email ");
            return View();
        }
    }
}