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
                cmd.CommandText = @"Select EmployeeID, Email, FirstName, LastName, PhotoPath, Title, Roles,BirthDate,Address,City,Country,HomePhone, Password
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
                            Email = dbReader["Email"].ToString(),
                            FirstName = dbReader["FirstName"].ToString(),
                            LastName = dbReader["LastName"].ToString(),
                            BirthDate = Convert.ToDateTime(dbReader["BirthDate"].ToString()),
                            Address = dbReader["Address"].ToString(),
                            City = dbReader["City"].ToString(),
                            Country = dbReader["Country"].ToString(),
                            HomePhone = dbReader["HomePhone"].ToString(),
                            Password = dbReader["Password"].ToString(),
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

        public bool ChangeForgotPassword(string newPass)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string email, string newPass)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Employees
                                  SET
                                    Password = @password
                                  WHERE Email = @email";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@password", newPass);
                cmd.Parameters.AddWithValue("@email", email);

                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }
            return rowsAffected > 0;
        }

        public Employee GetProfile(string email)
        {
            Employee data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Employees WHERE Email = @email";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@email", email);

                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dbReader.Read())
                    {
                        data = new Employee()
                        {
                            EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                            FirstName = Convert.ToString(dbReader["FirstName"]),
                            LastName = Convert.ToString(dbReader["LastName"]),
                            Title = Convert.ToString(dbReader["Title"]),
                            BirthDate = Convert.ToDateTime(dbReader["BirthDate"]),
                            HireDate = Convert.ToDateTime(dbReader["HireDate"]),
                            Address = Convert.ToString(dbReader["Address"]),
                            City = Convert.ToString(dbReader["City"]),
                            Country = Convert.ToString(dbReader["Country"]),
                            Email = Convert.ToString(dbReader["Email"]),
                            HomePhone = Convert.ToString(dbReader["HomePhone"]),
                            Notes = Convert.ToString(dbReader["Notes"]),
                            Password = Convert.ToString(dbReader["Password"]),
                            PhotoPath = Convert.ToString(dbReader["PhotoPath"])
                        };
                    }
                }

                connection.Close();
            }
            return data;
        }

        public bool UpdateProfile(Employee data)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE Employees
                                  SET   
                                    LastName = @lastName,
	                                FirstName = @firstName,
	                                Title = @title,
                                    BirthDate = @birthDate,
	                                Address = @address,
	                                City = @city,
	                                Country = @country,
	                                HomePhone = @homePhone,
                                    PhotoPath = @photoPath
                                  WHERE EmployeeID = @employeeID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@lastName", data.LastName);
                cmd.Parameters.AddWithValue("@firstName", data.FirstName);
                cmd.Parameters.AddWithValue("@title", data.Title);
                cmd.Parameters.AddWithValue("@birthDate", data.BirthDate);
                cmd.Parameters.AddWithValue("@Address", data.Address);
                cmd.Parameters.AddWithValue("@City", data.City);
                cmd.Parameters.AddWithValue("@Country", data.Country);
                cmd.Parameters.AddWithValue("@homePhone", data.HomePhone);
                cmd.Parameters.AddWithValue("@employeeID", data.EmployeeID);
                cmd.Parameters.AddWithValue("@photoPath", data.PhotoPath);

                rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());

                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
