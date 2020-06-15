using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Tên đầy đủ của user (firstname, lastname)
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Tên file ảnh của user
        /// </summary>
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Roles { get; set; }

    }
}
