using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        ///  kiểm tra thông tin đăng nhập  có hợp lệ không
        ///  hợp lệ thì trả về thông tin user
        ///  không thì trả về null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
      UserAccount Authorize(string userName, string password);
    }
}
