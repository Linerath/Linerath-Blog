using Linerath_Blog.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Linerath_Blog.Web.ViewModels
{
    public class CategoriesListViewModel : BaseViewModel
    {
        public List<Category> Categories { get; set; }

        public CategoriesListViewModel(String category, String searchText)
            : base(category, searchText)
        {
            Categories = new List<Category>();
        }
    }
}