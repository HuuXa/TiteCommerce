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
    public class OrderDAL : IOrderDAL
    {
        /// <summary>
        /// 
        /// </summary>
        private string connectionString;
        /// <summary>
        /// /
        /// </summary>
        /// <param name="connectionString"></param>
        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int Add(Order order)
        {
            int orderID = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Orders
                                          (
                                   
                                            CustomerID,
                                            EmployeeID,
                                            OrderDate,
                                            RequiredDate,
                                            ShippedDate,
                                            ShipperID,
                                            Freight,
                                            ShipAddress,
                                            ShipCity,
                                            ShipCountry
                                          )
                                          VALUES
                                          (
                                         
                                            @CustomerID,
                                            @EmployeeID,
                                            @OrderDate,
                                            @RequiredDate,
                                            @ShippedDate,
                                            @ShipperID,
                                            @Freight,
                                            @ShipAddress,
                                            @ShipCity,
                                            @ShipCountry
                                          );
                                          SELECT @@IDENTITY;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("EmployeeID", order.EmployeeID);
                cmd.Parameters.AddWithValue("OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("RequiredDate", order.RequiredDate);
                cmd.Parameters.AddWithValue("ShippedDate", order.ShippedDate);
                cmd.Parameters.AddWithValue("ShipperID", order.ShipperID);
                cmd.Parameters.AddWithValue("Freight", order.Freight);
                cmd.Parameters.AddWithValue("ShipAddress", order.ShipAddress);
                cmd.Parameters.AddWithValue("ShipCity", order.ShipCity);
                cmd.Parameters.AddWithValue("ShipCountry", order.ShipCountry);
                orderID = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return orderID;
        }

        public int Count(string searchValue)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT COUNT(*) FROM dbo.Orders
                                       WHERE (@searchValue = N'') OR (CustomerID LIKE @searchValue)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);

                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
                connection.Close();
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIDs"></param>
        /// <returns></returns>
        public bool Delete(int[] orderIDs)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"DELETE FROM Orders
                                            WHERE(OrderID = @OrderId)
                                              AND(OrderID NOT IN(SELECT OrderID FROM OrderDetails))";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.Add("@OrderID", SqlDbType.Int);
                foreach (int orderID in orderIDs)
                {
                    cmd.Parameters["@OrderID"].Value = orderID;
                    rowsAffected += Convert.ToInt32(cmd.ExecuteNonQuery());
                }

                connection.Close();
            }
            return rowsAffected == orderIDs.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Order Get(int orderID)
        {
            Order data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Orders WHERE OrderID = @OrderID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Order()
                        {
                            OrderID = Convert.ToInt32(dbReader["OrderID"]),
                            CustomerID = Convert.ToString(dbReader["CustomerID"]),
                            EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(dbReader["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(dbReader["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(dbReader["ShippedDate"]),
                            ShipperID = Convert.ToInt32(dbReader["ShipperID"]),
                            Freight = Convert.ToString(dbReader["Freight"]),
                            ShipAddress = Convert.ToString(dbReader["ShipAddress"]),
                            ShipCity = Convert.ToString(dbReader["ShipCity"]),
                            ShipCountry = Convert.ToString(dbReader["ShipCountry"]),
                        };
                    }
                }
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<Order> List(int page, int pageSize, string searchValue)
        {
            List<Order> data = new List<Order>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM 
                                        (
	                                        SELECT *, ROW_NUMBER() OVER(ORDER BY OrderID) AS RowNumber
	                                        FROM Orders
	                                        WHERE (@searchValue = N'') OR (CustomerID LIKE @searchValue)
                                        )AS t  WHERE t.RowNumber BETWEEN (@page - 1) * @pageSize + 1 AND (@page * @pageSize)
                                        ORDER BY t.RowNumber";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@page", page);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);;

                    using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dbReader.Read())
                        {
                            data.Add(new Order()
                            {
                                OrderID = Convert.ToInt32(dbReader["OrderID"]),
                                CustomerID = Convert.ToString(dbReader["CustomerID"]),
                                EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                                OrderDate = Convert.ToDateTime(dbReader["OrderDate"]),
                                RequiredDate = Convert.ToDateTime(dbReader["RequiredDate"]),
                                ShippedDate = Convert.ToDateTime(dbReader["ShippedDate"]),
                                ShipperID = Convert.ToInt32(dbReader["ShipperID"]),
                                Freight = Convert.ToString(dbReader["Freight"]),
                                ShipAddress = Convert.ToString(dbReader["ShipAddress"]),
                                ShipCity = Convert.ToString(dbReader["ShipCity"]),
                                ShipCountry = Convert.ToString(dbReader["ShipCountry"])
                            });
                        }
                    }
                }
                connection.Close();
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool Update(Order order)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE dbo.Orders SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, 
                                    OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, ShipperID = @ShipperID, 
                                    Freight = @Freight, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipCountry = @ShipCountry WHERE OrderID = @OrderID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("OrderID", order.OrderID);
                cmd.Parameters.AddWithValue("CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("EmployeeID", order.EmployeeID);
                cmd.Parameters.AddWithValue("OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("RequiredDate", order.RequiredDate);
                cmd.Parameters.AddWithValue("ShippedDate", order.ShippedDate);
                cmd.Parameters.AddWithValue("ShipperID", order.ShipperID);
                cmd.Parameters.AddWithValue("Freight", order.Freight);
                cmd.Parameters.AddWithValue("ShipAddress", order.ShipAddress);
                cmd.Parameters.AddWithValue("ShipCity", order.ShipCity);
                cmd.Parameters.AddWithValue("ShipCountry", order.ShipCountry);
                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }

    }
}
