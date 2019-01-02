using System;
using System.Linq;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;

namespace Linerath_Blog.DAL.Repositories
{
    public class MockArticleRepository : IArticleRepository
    {
        private List<Subject> subjects = new List<Subject>();
        private List<Article> articles = new List<Article>();

        public MockArticleRepository()
        {
            // subjects.
            subjects.Add(new Subject { Id = 0, Name = "Жизнь" });
            subjects.Add(new Subject { Id = 0, Name = "За Нерзула" });

            // articles.
            articles.Add(new Article
            {
                Id = 0,
                Title = "Welcome",
                Body = "To my in-development blog. I'm so excited about that idea.",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
            articles.Add(new Article
            {
                Id = 0,
                Title = "Eyeless",
                Body = @"Insane - Am I the only motherfucker with a brain?
                         I'm hearing voices but all they do is complain
                         How many times have you wanted to kill
                         Everything and everyone - Say you'll do it but never will
                              
                         You can't see California without Marlon Brando's eyes
                         Can't see California without Marlon Brando's eyes
                         You can't see California without Marlon Brando's eyes",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
            articles.Add(new Article
            {
                Id = 0,
                Title = "Кликбейтный заголовок!",
                Body = "Заголовок кликбейтный, а содержания нет. Фить Ха!.",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });

        }

        public List<Article> GetAllArticles()
        {
            return articles;
        }

        public Article GetArticleById(int id)
        {
            return articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
