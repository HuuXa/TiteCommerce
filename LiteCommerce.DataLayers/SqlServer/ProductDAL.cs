using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class ProductDAL : IProductDAL
    {
        private string connectionString;

        public ProductDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Add(Product product)
        {
            int productId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO Products
                                          (
	                                          ProductName,
	                                          SupplierID,
	                                          CategoryID,
	                                          QuantityPerUnit,
	                                          UnitPrice,
	                                          Descriptions,
	                                          PhotoPath
                                          )
                                          VALUES
                                          (
	                                          @productName,
	                                          @supplierID,
	                                          @categoryID,
	                                          @quantityPerUnit,
	                                          @unitPrice,
	                                          @descriptions,
	                                          @photoPath
                                          );
                                          SELECT @@IDENTITY;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("productName", product.ProductName);
                cmd.Parameters.AddWithValue("supplierID", product.SupplierID);
                cmd.Parameters.AddWithValue("categoryID", product.CategoryID);
                cmd.Parameters.AddWithValue("quantityPerUnit", product.QuantityPerUnit);
                cmd.Parameters.AddWithValue("unitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("descriptions", product.Descriptions);
                cmd.Parameters.AddWithValue("photoPath", product.PhotoPath);

                productId = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            return productId;
        }

        /// <summary>
        /// Đếm sô sản phẩm product
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
                    cmd.CommandText = @"SELECT COUNT(*) FROM dbo.Products
                                       WHERE (@searchValue = N'') OR (ProductName LIKE @searchValue)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);

                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
                connection.Close();
            }
            return count;
        }

        public bool Delete(int[] productIDs)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"DELETE FROM Products
                                            WHERE(ProductID = @productId)";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.Add("@productId", SqlDbType.Int);
                foreach (int productId in productIDs)
                {
                    cmd.Parameters["@productId"].Value = productId;
                    rowsAffected += Convert.ToInt32(cmd.ExecuteNonQuery());
                }

                connection.Close();
            }
            return rowsAffected == productIDs.Length;
        }

        public Product Get(int productID)
        {
            Product data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Products WHERE ProductID = @productID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@productID", productID);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Product()
                        {
                            ProductID = Convert.ToInt32(dbReader["ProductID"]),
                            ProductName = Convert.ToString(dbReader["ProductName"]),
                            SupplierID = Convert.ToInt32(dbReader["SupplierID"]),
                            CategoryID = Convert.ToInt32(dbReader["CategoryID"]),
                            QuantityPerUnit = Convert.ToString(dbReader["QuantityPerUnit"]),
                            UnitPrice = Convert.ToInt32(dbReader["UnitPrice"]),
                            Descriptions = Convert.ToString(dbReader["Descriptions"]),
                            PhotoPath = Convert.ToString(dbReader["PhotoPath"])
                        };
                    }
                }
                connection.Close();
            }
            return data;
        }

        public List<Product> List(int page, int pageSize, string searchValue, int categoryId, int supplierId)
        {
            List<Product> data = new List<Product>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM 
                                        (
	                                        SELECT *, ROW_NUMBER() OVER(ORDER BY ProductID) AS RowNumber
	                                        FROM dbo.Products
	                                        WHERE (@searchValue = N'') OR (ProductName LIKE @searchValue) AND (CategoryID = @categoryId) AND (SupplierID = @supplierId)
                                        )AS t  WHERE t.RowNumber BETWEEN (@page - 1) * @pageSize + 1 AND (@page * @pageSize)
                                        ORDER BY t.RowNumber";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@page", page);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@supplierId", supplierId);

                    using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dbReader.Read())
                        {
                            data.Add(new Product()
                            {
                                ProductID = Convert.ToInt32(dbReader["ProductID"]),
                                ProductName = Convert.ToString(dbReader["ProductName"]),
                                SupplierID = Convert.ToInt32(dbReader["SupplierID"]),
                                CategoryID = Convert.ToInt32(dbReader["CategoryID"]),
                                QuantityPerUnit = Convert.ToString(dbReader["QuantityPerUnit"]),
                                UnitPrice = Convert.ToInt32(dbReader["UnitPrice"]),
                                Descriptions = Convert.ToString(dbReader["Descriptions"]),
                                PhotoPath = Convert.ToString(dbReader["PhotoPath"])
                            });
                        }
                    }
                }
                connection.Close();
            }
            return data;
        }

        public bool Update(Product product)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE dbo.Suppliers SET ProductName = @ProductName, SupplierID = @SupplierID, 
                                    CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, 
                                    Descriptions = @Descriptions, PhotoPath = @PhotoPath WHERE ProductID = @ProductID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("SupplierID", product.SupplierID);
                cmd.Parameters.AddWithValue("CategoryID", product.CategoryID);
                cmd.Parameters.AddWithValue("QuantityPerUnit", product.QuantityPerUnit);
                cmd.Parameters.AddWithValue("UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("Descriptions", product.Descriptions);
                cmd.Parameters.AddWithValue("PhotoPath", product.PhotoPath);

                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
