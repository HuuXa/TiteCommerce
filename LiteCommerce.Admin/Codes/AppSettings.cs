﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LiteCommerce.Admin
{
    public class AppSettings
    {
        public static int DefaultPageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPageSize"]);
            }
        }
    }
}