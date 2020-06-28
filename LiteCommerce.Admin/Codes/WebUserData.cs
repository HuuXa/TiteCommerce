    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin
{
    /// <summary>
    /// Lưu thông tin liên quan đến tài khoản đăng nhập tại 1 phiên làm việc
    /// </summary>
    public class WebUserData
    {
        /// <summary>
        /// ID/tên đăng nhập của tài khoản
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Tên gọi/tên hiển thị của tài khoản
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Tên nhóm
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Thời điểm đăng nhập
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// Session ID
        /// </summary>
        public string SessionID { get; set; }
        /// <summary>
        /// Địa chỉ IP của user khi đăng nhập
        /// </summary>
        public string ClientIP { get; set; }
        /// <summary>
        /// anh
        /// (lưu ý: dữ liệu là chuỗi và không được chứa dấu |)
        /// </summary>
        public string Photo { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Chuyển thông tin tài khoản đăng nhập thành chuỗi để ghi Cookie
        /// </summary>
        /// <returns></returns>
        public string ToCookieString()
        {
            return string.Format($"{UserID}|{FullName}|{GroupName}|{LoginTime}|{SessionID}|{ClientIP}|{Photo}|{Title}|{LastName}|{FirstName}|{BirthDate}|{Address}|{City}|{Country}|{HomePhone}|{Password}|{Email}");
            //|{LastName}|{FirstName}|{BirthDate}|{Address}|{City}|{Country}|{HomePhone}|{Password}
        }

        /// <summary>
        /// Lấy thông tin tài khoản đăng nhập từ Cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static WebUserData FromCookieString(string cookie)
        {
            try
            {
                string[] infos = cookie.Split('|');
                if (infos.Length == 17)
                {
                    return new WebUserData()
                    {
                        UserID = infos[0],
                        FullName = infos[1],
                        GroupName = infos[2],
                        LoginTime = Convert.ToDateTime(infos[3]),
                        SessionID = infos[4],
                        ClientIP = infos[5],
                        Photo = infos[6],
                        Title = infos[7],
                        LastName = infos[8],
                        FirstName = infos[9],
                        BirthDate = Convert.ToDateTime(infos[10]),
                        Address = infos[11],
                        City = infos[12],
                        Country = infos[13],
                        HomePhone = infos[14],
                        Password = infos[15],
                        Email = infos[16],
                    };
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}