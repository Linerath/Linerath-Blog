using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Linerath_Blog.Web.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsRepository commentsRepository;

        public CommentsController(ICommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public PartialViewResult GetComments(int articleId)
        {
            List<Comment> comments = commentsRepository.GetComments(articleId);

            List<CommentViewModel> model = Mapper.Map<List<Comment>, List<CommentViewModel>>(comments);

            return PartialView("CommentsSectionPartial", model);
        }
    }
}