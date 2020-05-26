﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DomainModels
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Int16 UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

    }
}
