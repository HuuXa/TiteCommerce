using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IOrderDetailDAL
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
   
        int Add(OrderDetail data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(OrderDetail data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailIDs"></param>
        /// <returns></returns>
        bool Delete(string[] orderDetailIDs);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        OrderDetail Get(string orderDetailID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<OrderDetail> List(int page, int pageSize, string searchValue);

    }
}
