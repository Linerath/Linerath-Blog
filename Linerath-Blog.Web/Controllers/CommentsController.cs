using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [ChildActionOnly]
        public PartialViewResult GetComments(int articleId)
        {
            List<Comment> data = commentsRepository.GetComments(articleId);

            List<CommentViewModel> comments = Mapper.Map<List<Comment>, List<CommentViewModel>>(data);

            return PartialView("CommentsSectionPartial", (articleId, comments.AsEnumerable()));
        }

        public PartialViewResult AddComment(int articleId, String sender, String body)
        {
            sender = sender?.Trim();
            body = body?.Trim();

            commentsRepository.AddComment(articleId, new Comment
            {
                Body = body,
                Sender = sender,
                CreationDate = DateTime.Now,
            });

            return GetComments(articleId);
        }
    }
}