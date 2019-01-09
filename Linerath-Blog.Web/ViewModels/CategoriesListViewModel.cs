using System;
using Linerath_Blog.Web.Models;
using System.Collections.Generic;

namespace Linerath_Blog.Web.ViewModels
{
    public class CategoriesListViewModel : BaseViewModel
    {
        public List<CategoryModel> Categories { get; set; }

        public CategoriesListViewModel(String category, String searchText, bool? caseSensetive)
            : base(category, searchText, caseSensetive)
        {
            Categories = new List<CategoryModel>();
        }
    }
}