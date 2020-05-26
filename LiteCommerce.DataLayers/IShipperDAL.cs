using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IShipperDAL
    {
        /// <summary>
        /// bổ sung thêm 1 cái Shipper
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ID của Shipper được bổ sung( nhỏ hơn or = 0 nếu lỗi)</returns>
        int Add(Shipper data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Shipper data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        bool Delete(int[] shipperIDs);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        Shipper Get(int shipperID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Shipper> List(int page, int pageSize, string searchValue );

        int Count(string searchValue);
    }
}
