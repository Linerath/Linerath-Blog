using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int pageSize = 2;

            var res0 = PaginationService.Paginate(data, 2, pageSize).ToList();
            var res1 = PaginationService.Paginate(data, 3, pageSize).ToList();
            var res2 = PaginationService.Paginate(data, 4, pageSize).ToList();

            Assert.IsTrue(res0.Count() == 2);
            Assert.IsTrue(res1.Count() == 1);
            Assert.IsTrue(res2.Count() == 0);
            Assert.IsTrue(res0[0].Title == "T2");
            Assert.IsTrue(res1[0].Title == "T4");
        }

        [TestMethod]
        public void PaginationGettingTotalPagesWorks()
        {
            List<Article> data = new List<Article>
            {
                new Article { Id = 0, Title = "T0" },
                new Article { Id = 1, Title = "T1" },
                new Article { Id = 2, Title = "T2" },
                new Article { Id = 3, Title = "T3" },
                new Article { Id = 4, Title = "T4" },
            };
            int pageSize = 2;

            int totalPages = PaginationService.GetTotalPages(data, pageSize);

            Assert.IsTrue(totalPages == 3);
        }

        [TestMethod]
        public void PaginationPagesDividingWorks()
        {
            List<Article> data = new List<Article>
            {
                new Article { Id = 0, Title = "T0" },
                new Article { Id = 1, Title = "T1" },
                new Article { Id = 2, Title = "T2" },
                new Article { Id = 3, Title = "T3" },
                new Article { Id = 4, Title = "T4" },
            };
            int maxVisiblePages = 3;
            int totalPages = data.Count();

            int firstPage0 = PaginationService.GetBorderPages(3, totalPages, maxVisiblePages).Item1;
            int lastPage0 = PaginationService.GetBorderPages(3, totalPages, maxVisiblePages).Item2;
            //
            int firstPage1 = PaginationService.GetBorderPages(3, totalPages, 2).Item1;
            int lastPage1 = PaginationService.GetBorderPages(3, totalPages, 2).Item2;
            //
            int firstPage2 = PaginationService.GetBorderPages(3, totalPages, 4).Item1;
            int lastPage2 = PaginationService.GetBorderPages(3, totalPages, 4).Item2;
            //
            int firstPage3 = PaginationService.GetBorderPages(1, totalPages, 5).Item1;
            int lastPage3 = PaginationService.GetBorderPages(1, totalPages, 5).Item2;
            //
            int firstPage4 = PaginationService.GetBorderPages(3, totalPages, 1).Item1;
            int lastPage4 = PaginationService.GetBorderPages(3, totalPages, 1).Item2;
            //
            int firstPage5 = PaginationService.GetBorderPages(1, totalPages, maxVisiblePages).Item1;
            int lastPage5 = PaginationService.GetBorderPages(1, totalPages, maxVisiblePages).Item2;
            //
            int firstPage6 = PaginationService.GetBorderPages(5, totalPages, maxVisiblePages).Item1;
            int lastPage6 = PaginationService.GetBorderPages(5, totalPages, maxVisiblePages).Item2;
            //
            int firstPage7 = PaginationService.GetBorderPages(4, totalPages, maxVisiblePages).Item1;
            int lastPage7 = PaginationService.GetBorderPages(4, totalPages, maxVisiblePages).Item2;


            Assert.IsTrue(firstPage0 == 2, $"{nameof(firstPage0)} {firstPage0.ToString()}");
            Assert.IsTrue(lastPage0 == 4, $"{nameof(lastPage0)} {lastPage0.ToString()}");
            //
            Assert.IsTrue(firstPage1 == 3, $"{nameof(firstPage1)} {firstPage1.ToString()}");
            Assert.IsTrue(lastPage1 == 4, $"{nameof(lastPage1)} {lastPage1.ToString()}");
            //
            Assert.IsTrue(firstPage2 == 2, $"{nameof(firstPage2)} {firstPage2.ToString()}");
            Assert.IsTrue(lastPage2 == 5, $"{nameof(lastPage2)} {lastPage2.ToString()}");
            //
            Assert.IsTrue(firstPage3 == 1, $"{nameof(firstPage3)} {firstPage3.ToString()}");
            Assert.IsTrue(lastPage3 == 5, $"{nameof(lastPage3)} {lastPage3.ToString()}");
            //
            Assert.IsTrue(firstPage4 == 3, $"{nameof(firstPage4)} {firstPage4.ToString()}");
            Assert.IsTrue(lastPage4 == 3, $"{nameof(lastPage4)} {lastPage4.ToString()}");
            //
            Assert.IsTrue(firstPage5 == 1, $"{nameof(firstPage5)} {firstPage5.ToString()}");
            Assert.IsTrue(lastPage5 == 3, $"{nameof(lastPage5)} {lastPage5.ToString()}");
            //
            Assert.IsTrue(firstPage6 == 3, $"{nameof(firstPage6)} {firstPage6.ToString()}");
            Assert.IsTrue(lastPage6 == 5, $"{nameof(lastPage6)} {lastPage6.ToString()}");
            //
            Assert.IsTrue(firstPage7 == 3, $"{nameof(firstPage7)} {firstPage7.ToString()}");
            Assert.IsTrue(lastPage7 == 5, $"{nameof(lastPage7)} {lastPage7.ToString()}");

        }


        [TestMethod]
        public void ArticleTruncatingWorks()
        {
            String text0 = "Insane - Am I the only motherfucker with a brain?\n"
                          + "I'm hearing voices but all they do is complain\n"
                          + "How many times have you wanted to kill\n"
                          + "Everything and everyone - Say you'll do it but never will\n"
                          + "You can't see California without Marlon Brando's eyes\n\n"
                          + "Can't see California without Marlon Brando's eyes\n"
                          + "You can't see California without Marlon Brando's eyes\n";
            String expected0 = "Insane - Am I the only motherfucker with a brain?\n"
                              + "I'm hearing voices but all they do is complain";
            String expected1 = "Insane - Am I the only motherfucker with a brain?\n"
                               + "I'm hearing voices but all they do is complain\n"
                               + "How many times have you wanted to kill\n"
                               + "Everything and everyone - Say you'll do it but never will\n"
                               + "You can't see California without Marlon Brando's eyes";


            String result0 = ArticleService.GetTruncatedString(text0, 2);
            String result1 = ArticleService.GetTruncatedString(text0, 5);
            

            Assert.IsTrue(result0 == expected0);
            Assert.IsTrue(result1 == expected1);
        }
    }
}
