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
    /// <summary>
    /// để giao tiếp với csdl kết nối
    /// </summary>
    public class ShipperDAL : IShipperDAL
    {
     
        public string connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public ShipperDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Shipper data)
        {
            int shipperID = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Shippers
                                          (
	                         
												CompanyName,
												Phone

                                          )
                                          VALUES
                                          (
	                                          @CompanyName,
	                                          @Phone,
	                                   
                                          );
                                          SELECT @@IDENTITY;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@CompanyName", data.CompanyName);
                cmd.Parameters.AddWithValue("@Phone", data.Phone);


                shipperID = Convert.ToInt32(cmd.ExecuteScalar());

                connection.Close();
            }
            return shipperID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
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
                    cmd.CommandText = @"SELECT COUNT(*) FROM dbo.Shippers
                                       WHERE (@searchValue = N'') OR (CompanyName LIKE @searchValue)";
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
        /// <param name="shipperIDs"></param>
        /// <returns></returns>
        public bool Delete(int[] shipperIDs)
        {
            bool result = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"DELETE FROM Shippers
                                            WHERE(ShipperID = @shipperID)
                                              AND(ShipperID NOT IN(SELECT ShipperID FROM Orders))";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.Add("@shipperID", SqlDbType.Int);
                foreach (int shipperId in shipperIDs)
                {
                    cmd.Parameters["@shipperId"].Value = shipperId;
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public Shipper Get(int shipperID)
        {
            Shipper data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Shippers WHERE ShipperID = @shipperID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@shipperID", shipperID);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Shipper()
                        {
                            ShipperID = Convert.ToInt32(dbReader["ShipperID"]),
                            CompanyName = Convert.ToString(dbReader["CompanyName"]),
                            Phone = Convert.ToString(dbReader["Phone"]),
                            //TODO: Làm nốt các trường còn lại...
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
        public List<Shipper> List(int page, int pageSize, string searchValue)
        {
            List<Shipper> data = new List<Shipper>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM 
                                        (
	                                        SELECT *, ROW_NUMBER() OVER(ORDER BY ShipperID) AS RowNumber
	                                        FROM dbo.Shippers
	                                        WHERE (@searchValue = N'') OR (CompanyName LIKE @searchValue)
                                        )AS t  WHERE t.RowNumber BETWEEN (@page - 1) * @pageSize + 1 AND (@page * @pageSize)
                                        ORDER BY t.RowNumber";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@page", page);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);

                    using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dbReader.Read())
                        {
                            data.Add(new Shipper()
                            {
                                ShipperID = Convert.ToInt32(dbReader["ShipperID"]),
                                CompanyName = Convert.ToString(dbReader["CompanyName"]),
                                Phone = Convert.ToString(dbReader["Phone"])
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
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Update(Shipper data)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Suppliers 
	                                    SET 
		                                    CompanyName = @CompanyName, 
		                                    Phone = @Phone,
		                                 
	                                    WHERE ShipperID = @ShipperID";
                //UPDATE NHANVIEN SET DIACHI = 'Hanoi' WHERE ID = 3;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                //TODO: Bổ sung tham số cho lệnh cập nhật
                cmd.Parameters.AddWithValue("@ShipperID", data.ShipperID);
                cmd.Parameters.AddWithValue("@CompanyName", data.CompanyName);

                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
