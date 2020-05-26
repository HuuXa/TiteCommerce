using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin
{
    /// <summary>
    /// khởi tạo các chức năng tác nghiệp cho ứng dụng
    /// </summary>
    public static class BusinessLayerConfig
    {
        public static void Initialize()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["LiteCommerce"].ConnectionString;
            CatalogBLL.Initialize(ConnectionString);// bổ sung khởi tạp các BLL khác khi sử dụng
        }
    }
}