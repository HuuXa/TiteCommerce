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
    /// 
    /// </summary>
    public class CategorieDAL : ICategorieDAL
    {
        public string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectióntring"></param>
        public CategorieDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Categorie data)
        {
            throw new NotImplementedException();
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
                    cmd.CommandText = @"SELECT COUNT(*) FROM dbo.Categories
                                       WHERE (@searchValue = N'') OR (CategoryName LIKE @searchValue)";
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
        /// <param name="categorieIDs"></param>
        /// <returns></returns>
        public bool Delete(int[] categorieIDs)
        {
            throw new NotImplementedException();
        }

        public Categorie Get(int categorieID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<Categorie> List(int page, int pageSize, string searchValue)
        {
            List<Categorie> data = new List<Categorie>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM 
                                        (
	                                        SELECT *, ROW_NUMBER() OVER(ORDER BY CategoryID) AS RowNumber
	                                        FROM dbo.Categories
	                                        WHERE (@searchValue = N'') OR (CategoryName LIKE @searchValue)
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
                            data.Add(new Categorie()
                            {
                                CategoryID = Convert.ToInt32(dbReader["CategoryID"]),
                                CategoryName = Convert.ToString(dbReader["CategoryName"]),
                                Description = Convert.ToString(dbReader["Description"])

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
        public bool Update(Categorie data)
        {
            throw new NotImplementedException();
        }
    }
}
