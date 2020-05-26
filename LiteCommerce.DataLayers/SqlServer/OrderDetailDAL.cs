using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class OrderDetailDAL : IOrderDetailDAL
    {
        public string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectióntring"></param>
        public OrderDetailDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(OrderDetail data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string[] orderDetailIDs)
        {
            throw new NotImplementedException();
        }

        public OrderDetail Get(string orderDetailID)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> List(int page, int pageSize, string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderDetail data)
        {
            throw new NotImplementedException();
        }
    }
}
