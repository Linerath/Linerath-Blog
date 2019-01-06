using Linerath_Blog.Web.Models;
using System;
using System.Collections.Generic;

namespace Linerath_Blog.Web.ViewModels
{
    public class CategoriesListViewModel
    {
        public List<CategoryModel> Categories { get; set; }
        public String SearchText { get; set; }
        public bool CaseSensetive { get; set; }

        public CategoriesListViewModel()
        {
            Categories = new List<CategoryModel>();
        }
    }
}