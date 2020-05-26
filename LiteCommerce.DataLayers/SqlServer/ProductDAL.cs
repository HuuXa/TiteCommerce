using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class ProductDAL : IProductDAL
    {
        public string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectióntring"></param>
        public ProductDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Product data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }


        public bool Delete(int[] productIDs)
        {
            throw new NotImplementedException();
        }

    

        public Product Get(int productID)
        {
            throw new NotImplementedException();
        }

        public List<Product> List(int page, int pageSize, string searchValue)
        {
            throw new NotImplementedException();


        }

        public bool Update(Product data)
        {
            throw new NotImplementedException();
        }
    }
}
