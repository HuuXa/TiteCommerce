using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> ListOfCountries()
        {
            List<SelectListItem> listContries = new List<SelectListItem>();
            listContries.Add(new SelectListItem() { Value = "USA", Text = "my" });
            listContries.Add(new SelectListItem() { Value = "uk", Text = "Anh" });
            return listContries;
        }
    }
}