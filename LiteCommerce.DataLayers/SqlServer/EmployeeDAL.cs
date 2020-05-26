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
    public class EmployeeDAL : IEmployeeDAL
    {
        public string connectionString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectióntring"></param>
        public EmployeeDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add(Employee data)
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
                    cmd.CommandText = @"SELECT COUNT(*) FROM dbo.Employees
                                       WHERE (@searchValue = N'') OR (Title LIKE @searchValue)";
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
        /// <param name="employeeIDs"></param>
        /// <returns></returns>

        public bool Delete(int[] employeeIDs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>

        public Employee Get(int employeeID)
        {
            throw new NotImplementedException();
        }

        public List<Employee> List(int page, int pageSize, string searchValue)
        {
            List<Employee> data = new List<Employee>();
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM 
                                        (
	                                        SELECT *, ROW_NUMBER() OVER(ORDER BY EmployeeID) AS RowNumber
	                                        FROM dbo.Employees
	                                        WHERE (@searchValue = N'') OR (Title LIKE @searchValue)
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
                            data.Add(new Employee()
                            {
                                //SupplierID 
                                EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                                LastName = Convert.ToString(dbReader["LastName"]),
                                FirstName = Convert.ToString(dbReader["FirstName"]),
                                Title = Convert.ToString(dbReader["Title"]),
                                BirthDate = Convert.ToDateTime(dbReader["BirthDate"]),
                                HireDate = Convert.ToDateTime(dbReader["HireDate"]),
                                Email = Convert.ToString(dbReader["Email"]),
                                Address = Convert.ToString(dbReader["Address"]),
                                City = Convert.ToString(dbReader["City"]),
                                Country = Convert.ToString(dbReader["Country"]),
                                HomePhone = Convert.ToString(dbReader["HomePhone"]),
                                Notes = Convert.ToString(dbReader["Notes"]),
                                PhotoPath = Convert.ToString(dbReader["PhotoPath"]),
                                Password= Convert.ToString(dbReader["Password"]),

                            });
                        }
                    }
                }
                connection.Close();
            }
            return data;
        }

        public bool Update(Employee data)
        {
            throw new NotImplementedException();
        }
    }
}
