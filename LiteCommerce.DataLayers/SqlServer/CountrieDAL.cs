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
    public class CountrieDAL : ICountrieDAL
    {
        private string connectionString;

        public CountrieDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Countries> List(string searchValue)
        {
            List<Countries> data = new List<Countries>();

            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM dbo.Countries
                                    WHERE (@searchValue = N'') OR (Country LIKE @searchValue)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@searchValue", searchValue);

                    using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dbReader.Read())
                        {
                            data.Add(new Countries()
                            {
                                Country = Convert.ToString(dbReader["Country"]),
                  
                            });
                        }
                    }
                }
                connection.Close();
            }
            return data;
        }
    }
}
