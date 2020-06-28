using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;

namespace LiteCommerce.BussinessLayers
{
    /// <summary>
    /// 
    /// </summary>
    public static class HumanResourceBLL
    {
        private static IEmployeeDAL EmployeeDB { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            EmployeeDB = new DataLayers.SqlServer.EmployeeDAL(connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool Employee_CheckLogin(string email, string pass)
        {
            return EmployeeDB.CheckLogin(email, pass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool Employee_CheckEmail(string email, string type)
        {
            return EmployeeDB.CheckEmail( email,  type);
        }


        public static int Employee_Add(Employee data)
        {
            return EmployeeDB.Add(data);
        }
        /// <summary>
        /// Lấy 1 Employee
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public static Employee Employee_Get(int employeeID)
        {
            return EmployeeDB.Get(employeeID);
        }
        /// <summary>
        /// Cập nhập 1 Employee
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Employee_Update(Employee data)
        {
            return EmployeeDB.Update(data);
        }
        /// <summary>
        /// Xóa 1 Employee
        /// </summary>
        /// <param name="EmployeeIDs"></param>
        /// <returns></returns>
        public static bool Employee_Delete(int[] employeeIDs)
        {
            return EmployeeDB.Delete(employeeIDs);
        }
        public static bool Check_Email(string email, string type)
        {
            return EmployeeDB.CheckEmail( email, type);
        }
    }
}
