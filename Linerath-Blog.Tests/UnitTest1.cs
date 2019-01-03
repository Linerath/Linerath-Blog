using System;
using Linerath_Blog.DAL.Repositories;
using Linerath_Blog.Web.Controllers;
using Linerath_Blog.Web.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Linerath_Blog.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetControllerNameWorks()
        {
            //Mock<UnitOfWork> mock = new Mock<UnitOfWork>();
            //MockArticleRepository articleRepository = new MockArticleRepository();
            //mock.Setup(x => x.ArticleRepository).Returns(articleRepository);
            //ArticlesController articlesController = new ArticlesController(mock.Object);

            //String name = articlesController.GetControllerName();

            //Assert.IsTrue(name == "Articles");
        }
    }
}
