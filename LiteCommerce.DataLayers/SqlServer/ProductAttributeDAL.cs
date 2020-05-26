using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class ProductAttributeDAL : IProductAttributeDAL
    {

        public string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectióntring"></param>
        public ProductAttributeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(ProductAttribute data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string[] productAttributeIDs)
        {
            throw new NotImplementedException();
        }

        public ProductAttribute Get(string productAttributeID)
        {
            throw new NotImplementedException();
        }

        public List<ProductAttribute> List(int page, int pageSize, string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductAttribute data)
        {
            throw new NotImplementedException();
        }
    }
}
