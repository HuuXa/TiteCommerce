﻿using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{


    public static class CatalogBLL
    {
        /// <summary>
        /// 
        /// </summary>
        private static ISupplierDAL SupplierDB { get; set; }
        private static ICustomerDAL CustomerDB  { get; set; }
        private static IShipperDAL ShipperDB { get; set; }
        //private static IProductDAL ProductDB { get; set; }
        private static ICategorieDAL CategorieDB { get; set; }
        private static IEmployeeDAL EmployeeDB { get; set; }

        /// <summary>
        /// hàm sẽ được gọi để hởi tạo các chức năng tác nghiệp
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            SupplierDB = new DataLayers.SqlServer.SupplierDAL(connectionString);
            CustomerDB = new DataLayers.SqlServer.CustomerDAL(connectionString);
            ShipperDB = new DataLayers.SqlServer.ShipperDAL(connectionString);
            //ProductDB = new DataLayers.SqlServer.ProductDAL(connectionString);
            CategorieDB = new DataLayers.SqlServer.CategorieDAL(connectionString);
            EmployeeDB = new DataLayers.SqlServer.EmployeeDAL(connectionString);
        }



        //SUPPLIER
        public static Supplier Suppliers_Get(int supplierID)
        {
            return SupplierDB.Get(supplierID);
        }
        /// <summary>
        /// hiển thị ds các nhà cung cấp theo dạng phân trang
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize"> số dòng mỗi trang </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> Suppliers_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 1)
                pageSize = 30;
            return SupplierDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Suppliers_Count(string searchValue)
        {
            return SupplierDB.Count(searchValue);
        }

        // CUSTOMER

        public static Customer Customer_Get(String customerID)
        {
            return CustomerDB.Get(customerID);
        }
        /// <summary>
        /// hiển thị ds các nhà cung cấp theo dạng phân trang
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize"> số dòng mỗi trang </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> Customer_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 1)
                pageSize = 30;
            return CustomerDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Customer_Count(string searchValue)
        {
            return CustomerDB.Count(searchValue);
        }

        //SHIPPER
        public static Shipper Shipper_Get(int shipperID)
        {
            return ShipperDB.Get(shipperID);
        }
        /// <summary>
        /// hiển thị ds các nhà cung cấp theo dạng phân trang
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize"> số dòng mỗi trang </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Shipper> Shipper_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 1)
                pageSize = 30;
            return ShipperDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Shipper_Count(string searchValue)
        {
            return ShipperDB.Count(searchValue);
        }

        ///PRODUCT

        /// <summary>
        /// hiển thị ds các nhà cung cấp theo dạng phân trang
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize"> số dòng mỗi trang </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        //public static List<Product> Product_List(int page, int pageSize, string searchValue)
        //{
        //    if (page < 1)
        //        page = 1;
        //    if (pageSize < 1)
        //        pageSize = 30;
        //    return ProductDB.List(page, pageSize, searchValue);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="searchValue"></param>
        ///// <returns></returns>
        //public static int Product_Count(string searchValue)
        //{
        //    return ProductDB.Count(searchValue);
        //}

        ///CATEGORIE
        public static Categorie Categorie_Get(int categoryID)
        {
            return CategorieDB.Get(categoryID);
        }
        /// <summary>
        /// hiển thị ds các nhà cung cấp theo dạng phân trang
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize"> số dòng mỗi trang </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Categorie> Categorie_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 1)
                pageSize = 30;
            return CategorieDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Categorie_Count(string searchValue)
        {
            return CategorieDB.Count(searchValue);
        }

        ///EMPLOYEES
        public static Employee Employee_Get(int employeeID)
        {
            return EmployeeDB.Get(employeeID);
        }
        /// <summary>
        /// hiển thị ds các nhà cung cấp theo dạng phân trang
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize"> số dòng mỗi trang </param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Employee> Employee_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 1)
                pageSize = 30;
            return EmployeeDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Employee_Count(string searchValue)
        {
            return EmployeeDB.Count(searchValue);
        }



    }
}
