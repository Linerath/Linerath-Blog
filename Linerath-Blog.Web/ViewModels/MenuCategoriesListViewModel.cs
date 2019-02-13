using System;
using Linerath_Blog.Web.Models;
using System.Collections.Generic;

namespace Linerath_Blog.Web.ViewModels
{
    public class MenuCategoriesListViewModel : BaseViewModel
    {
        public List<MenuCategoryModel> Categories { get; set; }

        public MenuCategoriesListViewModel(String category, String searchText)
            : base(category, searchText)
        {
            Categories = new List<MenuCategoryModel>();
        }
    }
}