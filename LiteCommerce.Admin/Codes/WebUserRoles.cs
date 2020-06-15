using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin
{
    /// <summary>
    /// Định nghĩa danh sách các Role của user
    /// </summary>
    public class WebUserRoles
    {
        /// <summary>
        /// Không xác định
        /// </summary>
        public const string ANONYMOUS = "anonymous";
        /// <summary>
        /// Nhân viên bán hàng
        /// </summary>
        public const string Saleman = "Saleman";
        /// <summary>
        /// Quản trị tài khoản
        /// </summary>
        public const string Accountant = "Accountant";
        /// <summary>
        /// Quản trị dữ liệu
        /// </summary>
        public const string DataManage = "DataManage";
    }
}