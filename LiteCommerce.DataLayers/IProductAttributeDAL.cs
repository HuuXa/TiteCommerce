using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    public interface IProductAttributeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(ProductAttribute data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(ProductAttribute data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productAttributeIDs"></param>
        /// <returns></returns>
        bool Delete(string[] productAttributeIDs);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productAttributeID"></param>
        /// <returns></returns>
        ProductAttribute Get(string productAttributeID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<ProductAttribute> List(int page, int pageSize, string searchValue);
    }
}
