using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SqlServer;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BussinessLayers
{
    public static class UserAccountBLL
    {
        private static IEmployeeDAL EmployeeDB { get; set; }

        private static string connectionString;

        public static void Initialize(string connectionString)
        {
            EmployeeDB = new DataLayers.SqlServer.EmployeeDAL(connectionString);
            UserAccountBLL.connectionString = connectionString;
        }

        private static IUserAccountDAL UserAccountDB { get; set; }


        public static UserAccount Authorize(string username, string password, UserAccountTypes userTypes)
        {
            IUserAccountDAL UserAccountDB = null;
            switch (userTypes)
            {
                case UserAccountTypes.Employee:
                    UserAccountDB = new EmployeeUserAccountDAL(connectionString);
                    break;
                //case UserAccountTypes.Customer:
                //    UserAccountDB = new CustomerUserAccountDAL(connectionString);
                //    break;
                default:
                    throw new Exception("user not valid");
            }
            return UserAccountDB.Authorize(username, password);
        }
        public static Employee GetProfile(string email)
        {
            IUserAccountDAL UserAccountDB = new EmployeeUserAccountDAL(connectionString);
            return UserAccountDB.GetProfile(email);
        }
        public static bool UpdateProfile(Employee data)
        {
            IUserAccountDAL UserAccountDB = new EmployeeUserAccountDAL(connectionString);
            return UserAccountDB.UpdateProfile(data);
        }
        public static bool Check_Pass(string email, string pass)
        {
            return EmployeeDB.CheckLogin(email, pass);
        }
        public static bool Change_Pass(string email, string pass)
        {
            IUserAccountDAL UserAccountDB = new EmployeeUserAccountDAL(connectionString);
            return UserAccountDB.ChangePassword(email, pass);
        }
        public static bool CheckEmail(string email, string type)
        {
            return EmployeeDB.CheckEmail( email,  type);
        }
    }
}
