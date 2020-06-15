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
        private static string connectionString;

        private static IUserAccountDAL UserAccountDB { get; set; }

        public static void Initialize(string connectionString)
        {
            UserAccountBLL.connectionString = connectionString;
        }
        public static UserAccount Authorize(string username, string password, UserAccountTypes userTypes)
        {
            IUserAccountDAL UserAccountDB = null;
            switch (userTypes)
            {
                case UserAccountTypes.Employee:
                    UserAccountDB = new EmployeeUserAccountDAL(connectionString);
                    break;
                case UserAccountTypes.Customer:
                    UserAccountDB = new CustomerUserAccountDAL(connectionString);
                    break;
                default:
                    throw new Exception("user not valid");
            }
            return UserAccountDB.Authorize(username, password);
        }
    }
}
