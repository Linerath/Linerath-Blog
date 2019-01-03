using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.DAL.Repositories;
using Linerath_Blog.Web.Controllers;
using Linerath_Blog.Web.Infrastructure;
using Linerath_Blog.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Linerath_Blog.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PaginationWorks()
        {
            List<Article> data = new List<Article>
            {
                new Article { Id = 0, Title = "T0" },
                new Article { Id = 1, Title = "T1" },
                new Article { Id = 2, Title = "T2" },
                new Article { Id = 3, Title = "T3" },
                new Article { Id = 4, Title = "T4" },
            };

            var res0 = PaginationService.Paginate(data, 2).ToList();
            var res1 = PaginationService.Paginate(data, 3).ToList();
            var res2 = PaginationService.Paginate(data, 4).ToList();
            var totalPages = PaginationService.GetTotalPages(data);

            Assert.IsTrue(res0.Count() == 2);
            Assert.IsTrue(res1.Count() == 1);
            Assert.IsTrue(res2.Count() == 0);
            Assert.IsTrue(res0[0].Title == "T2");
            Assert.IsTrue(res1[0].Title == "T4");
            Assert.IsTrue(totalPages == 3);
        }
    }
}
