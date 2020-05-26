using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface ISupplierDAL
    {
        /// <summary>
        /// bổ sung thêm 1 cái supplier
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ID của supplier được bổ sung( nhỏ hơn or = 0 nếu lỗi)</returns>
        int Add(Supplier data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Supplier data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        bool Delete(int[] supplierIDs);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        Supplier Get(int supplierID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Supplier> List(int page, int pageSize, string searchValue );
        int Count(string searchValue);
  
    }
}
