using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiteCommerce.BussinessLayers
{
    /// <summary>
    /// 
    /// </summary>
    public static class CatalogBLL
    {
        /// <summary>
        /// 
        /// </summary>
        private static ISupplierDAL SupplierDB { get; set; }
        private static ICustomerDAL CustomerDB { get; set; }
        private static ICategoryDAL CategoryDB { get; set; }
        private static IProductDAL ProductDB { get; set; }
        private static IShipperDAL ShipperDB { get; set; }
        private static IEmployeeDAL EmployeeDB { get; set; }
        private static ICountrieDAL CountrieDB { get; set; }
        private static IOrderDAL OrderDB { get; set; }
        private static IOrderDetailDAL OrderDetailDB { get; set; }
        private static IProductAttributeDAL ProductAttributeDB { get; set; }

        /// <summary>
        /// Hàm này được gọi để khởi tạo các chức năng tác nghiệp
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            SupplierDB = new DataLayers.SqlServer.SupplierDAL(connectionString);
            CustomerDB = new DataLayers.SqlServer.CustomerDAL(connectionString);
            ProductDB = new DataLayers.SqlServer.ProductDAL(connectionString);
            ShipperDB = new DataLayers.SqlServer.ShipperDAL(connectionString);
            CategoryDB = new DataLayers.SqlServer.CategoryDAL(connectionString);
            EmployeeDB = new DataLayers.SqlServer.EmployeeDAL(connectionString);
            CountrieDB = new DataLayers.SqlServer.CountrieDAL(connectionString);
            OrderDB = new DataLayers.SqlServer.OrderDAL(connectionString);
            OrderDetailDB = new DataLayers.SqlServer.OrderDetailDAL(connectionString);
            ProductAttributeDB = new DataLayers.SqlServer.ProductAttributeDAL(connectionString);
        }

        #region Supplier
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> Supplier_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
                pageSize = 30;
                    
            return SupplierDB.List(page, pageSize, searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Supplier_Count(string searchValue)
        {
            return SupplierDB.Count(searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static int Supplier_Add(Supplier supplier)
        {
            return SupplierDB.Add(supplier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        public static bool Supplier_Delete(int[] supplierIDs)
        {
            return SupplierDB.Delete(supplierIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier Supplier_Get(int supplierID)
        {
            return SupplierDB.Get(supplierID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static bool Supplier_Update(Supplier supplier)
        {
            return SupplierDB.Update(supplier);
        }
        #endregion

        #region Customer
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> Customer_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static string Customer_Add(Customer customer)
        {
            return CustomerDB.Add(customer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer Customer_Get(string customerID)
        {
            return CustomerDB.Get(customerID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIDs"></param>
        /// <returns></returns>
        public static bool Customer_Delete(string[] customerIDs)
        {
            return CustomerDB.Delete(customerIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static bool Customer_Update(Customer customer)
        {
            return CustomerDB.Update(customer);
        }
        #endregion

        #region Shipper
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Shipper> Shipper_List(string searchValue)
        {
            return ShipperDB.List(searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Shippers_Count(string searchValue)
        {
            return ShipperDB.Count(searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        public static int Shipper_Add(Shipper shipper)
        {
            return ShipperDB.Add(shipper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static Shipper Shipper_Get(int shipperID)
        {
            return ShipperDB.Get(shipperID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperIDs"></param>
        /// <returns></returns>
        public static bool Shipper_Delete(int[] shipperIDs)
        {
            return ShipperDB.Delete(shipperIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipper"></param>
        /// <returns></returns>
        public static bool Shipper_Update(Shipper shipper)
        {
            return ShipperDB.Update(shipper);
        }
        #endregion

        #region Category 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Category> Category_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
                pageSize = 30;
            return CategoryDB.List(page, pageSize, searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Category_Count(string searchValue)
        {
            return CategoryDB.Count(searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static int Category_Add(Category category)
        {
            return CategoryDB.Add(category);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryIDs"></param>
        /// <returns></returns>
        public static bool Category_Delete(int[] categoryIDs)
        {
            return CategoryDB.Delete(categoryIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category Category_Get(int categoryID)
        {
            return CategoryDB.Get(categoryID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool Category_Update(Category category)
        {
            return CategoryDB.Update(category);
        }
        #endregion

        #region Employee
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static int Employee_Add(Employee employee)
        {
            return EmployeeDB.Add(employee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
   

        public static int Employee_Count(string searchValue, string country)
        {
            return EmployeeDB.Count(searchValue, country);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeIDs"></param>
        /// <returns></returns>
        public static bool Employee_Delete(int[] employeeIDs)
        {
            return EmployeeDB.Delete(employeeIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool Employee_Update(Employee employee)
        {
            return EmployeeDB.Update(employee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee Employee_Get(int employeeID)
        {
            return EmployeeDB.Get(employeeID);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Employee> Employee_List(int page, int pageSize, string searchValue, string country)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
                pageSize = 30;
            return EmployeeDB.List(page, pageSize, searchValue, country);
        }
        #endregion
       
        #region Product
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static int Product_Add(Product product, HttpPostedFileBase file)
        {
            return ProductDB.Add(product, file);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Product_Count(string searchValue, string categoryId, string supplierId)
        {
            return ProductDB.Count(searchValue, categoryId, supplierId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeIDs"></param>
        /// <returns></returns>
        public static bool Product_Delete(int[] productIDs)
        {
            return ProductDB.Delete(productIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool Product_Update(Product product)
        {
            return ProductDB.Update(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Product Product_Get(int productID)
        {
            return ProductDB.Get(productID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Product> Product_List(int page, int pageSize, string searchValue, int categoryId, int supplierId)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
                pageSize = 30;
            return ProductDB.List(page, pageSize, searchValue, categoryId, supplierId);
        }

        #endregion

        #region Countrie
        public static List<Countries> Countrie_List(string searchValue)
        {
            return CountrieDB.List(searchValue);
        }
        #endregion

        #region Order
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Order> Order_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
                pageSize = 30;

            return OrderDB.List(page, pageSize, searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int Order_Count(string searchValue)
        {
            return OrderDB.Count(searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static int Order_Add(Order order)
        {
            return OrderDB.Add(order);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        public static bool Order_Delete(int[] orderIDs)
        {
            return OrderDB.Delete(orderIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Order Order_Get(int orderID)
        {
            return OrderDB.Get(orderID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static bool Order_Update(Order order)
        {
            return OrderDB.Update(order);
        }
        #endregion

        #region OrderDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<OrderDetail> OrderDetail_List(int page, int pageSize, string searchValue)
        {
            if (page < 1)
                page = 1;
            if (pageSize <= 0)
                pageSize = 30;

            return OrderDetailDB.List(page, pageSize, searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int OrderDetail_Count(string searchValue)
        {
            return OrderDetailDB.Count(searchValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static int OrderDetail_Add(OrderDetail orderDetail)
        {
            return OrderDetailDB.Add(orderDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierIDs"></param>
        /// <returns></returns>
        public static bool OrderDetail_Delete(int[] orderDetailIDs)
        {
            return OrderDetailDB.Delete(orderDetailIDs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static OrderDetail OrderDetail_Get(int orderDetailID)
        {
            return OrderDetailDB.Get(orderDetailID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static bool OrderDetail_Update(OrderDetail orderDetail)
        {
            return OrderDetailDB.Update(orderDetail);
        }
        #endregion

        #region ProductAttribute
        public static List<ProductAttribute> ProductAttribute_List(int productID)
        {
            return ProductAttributeDB.List(productID);
        }
        public static int ProductAttribute_Add(ProductAttribute data)
        {
            return ProductAttributeDB.Add(data);
        }
        public static ProductAttribute ProductAttribute_Get(int attributeID)
        {
            return ProductAttributeDB.Get(attributeID);
        }
        public static bool ProductAttribute_Update(ProductAttribute data)
        {
            return ProductAttributeDB.Update(data);
        }
        public static bool ProductAttribute_Delete(int[] atrributeIDs)
        {
            return ProductAttributeDB.Delete(atrributeIDs);
        }
        #endregion
    }
}
