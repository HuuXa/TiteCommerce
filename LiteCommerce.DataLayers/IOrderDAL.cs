using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IOrderDAL
    {
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Order data);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="data"></param>
       /// <returns></returns>
        bool Update(Order data);
   /// <summary>
   /// 
   /// </summary>
   /// <param name="orderIDs"></param>
   /// <returns></returns>
        bool Delete(string[] orderIDs);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        Order Get(string orderID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
   
        List<Order> List(int page, int pageSize, string searchValue);
    }
}
