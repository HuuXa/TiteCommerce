using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class OrderDAL : IOrderDAL
    {
        public string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectióntring"></param>
        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Order data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string[] orderIDs)
        {
            throw new NotImplementedException();
        }

        public Order Get(string orderID)
        {
            throw new NotImplementedException();
        }

        public List<Order> List(int page, int pageSize, string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order data)
        {
            throw new NotImplementedException();
        }
    }
}
