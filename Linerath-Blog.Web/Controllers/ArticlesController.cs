﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;
using Linerath_Blog.Web.ViewModels;

namespace Linerath_Blog.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticlesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ViewResult All()
        {
            List<Article> articles = unitOfWork.ArticleRepository.GetAllArticles();

            List<ArticleSummaryViewModel> model = Mapper.Map<List<Article>, List<ArticleSummaryViewModel>>(articles);

            List<ArticleSummaryViewModel> list = new List<ArticleSummaryViewModel>
            {
                new ArticleSummaryViewModel
                {
                    Title = "Welcome",
                    Body = "To my in-development blog. I'm so excited about that idea.",
                    CreationDate = DateTime.Now
                },
                new ArticleSummaryViewModel
                {
                    Title = "Eyeless",
                    Body = @"Insane - Am I the only motherfucker with a brain?
                             I'm hearing voices but all they do is complain
                             How many times have you wanted to kill
                             Everything and everyone - Say you'll do it but never will
                             
                             You can't see California without Marlon Brando's eyes
                             Can't see California without Marlon Brando's eyes
                             You can't see California without Marlon Brando's eyes",
                    CreationDate = DateTime.Now
                },
                new ArticleSummaryViewModel
                {
                    Title = "Кликбейтный заголовок!",
                    Body = "Заголовок кликбейтный, а содержание - пустышка.",
                    CreationDate = DateTime.Now,
                }
            };

            return View(model);
        }
    }
}