using LiteCommerce.BussinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin
{
    public static class SelectListHelper
    {
        //public static List<SelectListItem> ListOfCountry() {
        //    List<SelectListItem> listCountries = new List<SelectListItem>();
        //    listCountries.Add(new SelectListItem() { Value = "USA", Text = "United States of America" });
        //    listCountries.Add(new SelectListItem() { Value = "UK", Text = "England" });
        //    listCountries.Add(new SelectListItem() { Value = "Japan", Text = "Japan" });
        //    listCountries.Add(new SelectListItem() { Value = "Australia", Text = "Australia" });
        //    listCountries.Add(new SelectListItem() { Value = "Sweden", Text = "Sweden" });
        //    listCountries.Add(new SelectListItem() { Value = "Brazil", Text = "Brazil" });
        //    listCountries.Add(new SelectListItem() { Value = "Germany", Text = "Germany" });
        //    listCountries.Add(new SelectListItem() { Value = "Italy", Text = "Italy" });
        //    listCountries.Add(new SelectListItem() { Value = "Norway", Text = "Norway" });
        //    listCountries.Add(new SelectListItem() { Value = "France", Text = "France" });
        //    listCountries.Add(new SelectListItem() { Value = "Singapore", Text = "Singapore" });
        //    listCountries.Add(new SelectListItem() { Value = "Denmark", Text = "Denmark" });
        //    listCountries.Add(new SelectListItem() { Value = "Netherlands", Text = "Netherlands" });
        //    listCountries.Add(new SelectListItem() { Value = "Finland", Text = "Finland" });
        //    listCountries.Add(new SelectListItem() { Value = "Canada", Text = "Canada" });
        //    listCountries.Add(new SelectListItem() { Value = "Venezuela", Text = "Venezuela" });
        //    listCountries.Add(new SelectListItem() { Value = "Belgium", Text = "Belgium" });
        //    listCountries.Add(new SelectListItem() { Value = "Mexico", Text = "Mexico" });
        //    listCountries.Add(new SelectListItem() { Value = "Argentina", Text = "Argentina" });
        //    listCountries.Add(new SelectListItem() { Value = "Switzerland", Text = "Switzerland" });
        //    listCountries.Add(new SelectListItem() { Value = "Spain", Text = "Spain" });
        //    listCountries.Add(new SelectListItem() { Value = "Poland", Text = "Poland" });
        //    listCountries.Add(new SelectListItem() { Value = "Portugal", Text = "Portugal" });
        //    return listCountries;
        //}
        public static List<SelectListItem> Countries(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "", Text = "-- Choose Countries --" });
            }
            foreach (var item in CatalogBLL.Countrie_List(""))
            {
                list.Add(new SelectListItem()
                {
                    Value = item.Country.ToString(),
                    Text = item.Country,
                });
            }
            return list;
        }

        public static List<SelectListItem> ListOfTitle()
        {
            List<SelectListItem> listTitle = new List<SelectListItem>();
            listTitle.Add(new SelectListItem() { Value = "Sales Representative", Text = "Sales Representative" });
            listTitle.Add(new SelectListItem() { Value = "Vice President, Sales", Text = "Vice President, Sales" });
            listTitle.Add(new SelectListItem() { Value = "Sales Manager", Text = "Sales Manager" });
            listTitle.Add(new SelectListItem() { Value = "Inside Sales Coordinator", Text = "Inside Sales Coordinator" });
            return listTitle;
        }
        public static List<SelectListItem> Categories(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "0", Text = "All Category" });
            }
            foreach (var item in CatalogBLL.Category_List(1, CatalogBLL.Category_Count(""), ""))
            {
                list.Add(new SelectListItem()
                {
                    Value = item.CategoryID.ToString(),
                    Text = item.CategoryName,
                });
            }
            return list;
        }
        public static List<SelectListItem> Suppliers(bool allowSelectAll = true)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (allowSelectAll)
            {
                list.Add(new SelectListItem() { Value = "0", Text = "All Supplier" });
            }
            foreach (var item in CatalogBLL.Supplier_List(1, -1, ""))
            {
                list.Add(new SelectListItem()
                {
                    Value = item.SupplierID.ToString(),
                    Text = item.CompanyName,
                });
            }

            return list;
        }
    }
}