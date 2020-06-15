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
    /// Kiểm tra thông tin đăng nhập của nhân viên
    /// </summary>
    public class EmployeeUserAccountDAL : IUserAccountDAL
    {
        private string connectionString;

        public EmployeeUserAccountDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserAccount Authorize(string email, string password)
        {
       /// TODO: kiểm tra thông tin đăng nhập thừ DB, trả về thông tin đăng nhập
            //return new UserAccount()
            //{
            //    // TODO:  get CSDL
            //    UserID = username,
            //    FullName = "HUU XA xa",
            //    Photo = "huy.jpg",
            //};
            //TODO: kt thông tin đn dựa vào bảng Employees
            UserAccount employee = null;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select EmployeeID, FirstName, LastName, PhotoPath, Title, Roles
                                    from Employees 
                                    where Email = @email And Password = @password";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        employee = new UserAccount()
                        {

                            UserID = dbReader["EmployeeID"].ToString(),
                            FullName = $"{dbReader["FirstName"]} {dbReader["LastName"]}",
                            Photo = dbReader["PhotoPath"].ToString(),
                            Title = dbReader["Title"].ToString(),
                            Roles = dbReader["Roles"].ToString()
                        };
                    }

                }
                connection.Close();

            }
            return employee;
        }
    }
}
