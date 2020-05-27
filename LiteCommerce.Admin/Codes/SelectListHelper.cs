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
            List<SelectListItem> listCountries = new List<SelectListItem>();
            listCountries.Add(new SelectListItem() { Value = "USA", Text = "United States of America" });
            listCountries.Add(new SelectListItem() { Value = "UK", Text = "England" });
            listCountries.Add(new SelectListItem() { Value = "Japan", Text = "Japan" });
            listCountries.Add(new SelectListItem() { Value = "Australia", Text = "Australia" });
            listCountries.Add(new SelectListItem() { Value = "Sweden", Text = "Sweden" });
            listCountries.Add(new SelectListItem() { Value = "Brazil", Text = "Brazil" });
            listCountries.Add(new SelectListItem() { Value = "Germany", Text = "Germany" });
            listCountries.Add(new SelectListItem() { Value = "Italy", Text = "Italy" });
            listCountries.Add(new SelectListItem() { Value = "Norway", Text = "Norway" });
            listCountries.Add(new SelectListItem() { Value = "France", Text = "France" });
            listCountries.Add(new SelectListItem() { Value = "Singapore", Text = "Singapore" });
            listCountries.Add(new SelectListItem() { Value = "Denmark", Text = "Denmark" });
            listCountries.Add(new SelectListItem() { Value = "Netherlands", Text = "Netherlands" });
            listCountries.Add(new SelectListItem() { Value = "Finland", Text = "Finland" });
            listCountries.Add(new SelectListItem() { Value = "Canada", Text = "Canada" });
            listCountries.Add(new SelectListItem() { Value = "Venezuela", Text = "Venezuela" });
            listCountries.Add(new SelectListItem() { Value = "Belgium", Text = "Belgium" });
            listCountries.Add(new SelectListItem() { Value = "Mexico", Text = "Mexico" });
            listCountries.Add(new SelectListItem() { Value = "Argentina", Text = "Argentina" });
            listCountries.Add(new SelectListItem() { Value = "Switzerland", Text = "Switzerland" });
            listCountries.Add(new SelectListItem() { Value = "Spain", Text = "Spain" });
            listCountries.Add(new SelectListItem() { Value = "Poland", Text = "Poland" });
            listCountries.Add(new SelectListItem() { Value = "Portugal", Text = "Portugal" });
            return listCountries;
        }
    }
}