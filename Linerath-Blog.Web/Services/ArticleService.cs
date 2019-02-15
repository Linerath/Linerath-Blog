using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Linerath_Blog.Web.Enums;
using Linerath_Blog.Web.Models;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Extensions;

namespace Linerath_Blog.Web.Services
{
    public static class ArticleService
    {
        public const int MAX_LINES_COUNT = 5;
        public const int MAX_ARTICLE_LENGHT = 675;
        public readonly static Dictionary<ArchiveFilter, String> ArchiveFilters = new Dictionary<ArchiveFilter, String>
        {
            { ArchiveFilter.Alphabet, "Алфавиту" },
            { ArchiveFilter.Date, "Дате" },
        };
        
        public static Article FormatArticle(Article article)
        {
            String[] separator = { "\r\n", "\r", "\n" };

            String[] bodyArr = article.Body.Split(separator, StringSplitOptions.None);
            String[] summaryArr = article.Summary.Split(separator, StringSplitOptions.None);

            StringBuilder body = new StringBuilder();
            StringBuilder summary = new StringBuilder();

            for (int i = 0; i < bodyArr.Length; i++)
            {
                String formattedLine = FormatLine(bodyArr[i], i == 0);
                body.Append(formattedLine);
            }

            for (int i = 0; i < summaryArr.Length; i++)
            {
                String formattedLine = FormatLine(summaryArr[i], i == 0);
                summary.Append(formattedLine);
            }

            article.Body = body.ToString();
            article.Summary = summary.ToString();

            return article;
        }

        public static void FormatArticle(String title, String pathToBody, String pathToSummary, DateTime creationDate)
        {
            if (!File.Exists(pathToBody) || !File.Exists(pathToSummary))
                return;

            title = title.Replace("'", "''");

            String fileName = Path.GetFileName(pathToBody);
            String pathToNewFile = pathToBody.Remove(pathToBody.LastIndexOf('\\')) + $"\\formatted\\{fileName}";

            StringBuilder body = new StringBuilder();
            StringBuilder summary = new StringBuilder();

            bool first = true;
            foreach (String line in File.ReadLines(pathToBody))
            {
                String formattedLine = FormatLine(line, first);

                if (first)
                    first = false;

                body.Append(formattedLine);
            }

            first = true;
            foreach (String line in File.ReadLines(pathToSummary))
            {
                String formattedLine = FormatLine(line, first);

                if (first)
                    first = false;

                summary.Append(formattedLine);
            }

            String result = $"(N'{title}', N'{body.ToString()}', N'{summary.ToString()}', '{creationDate.ToSqlString()}')";

            File.WriteAllText(pathToNewFile, result);
        }

        private static String FormatLine(String line, bool first)
        {
            if (String.IsNullOrEmpty(line))
            {
                return "<br/>";
            }
            else
            {
                line = line.Replace("'", "''");

                line = first
                    ? line
                    : "<br/>" + line;

                return line;
            }
        }

        public static void CalculateCategoriesCount(List<MenuCategoryModel> categories, List<Article> allArticles)
        {
            foreach (var category in categories)
            {
                foreach (var article in allArticles)
                {
                    if (article.Categories.Any(x => x.Name == category.Name))
                        category.Count++;
                }
            }
        }

        public static List<ArticleTitleGroup> GroupArticles(List<ArticleTitle> articles, ArchiveFilter filter)
        {
            if (articles == null)
                throw new ArgumentNullException("articles");

            List<ArticleTitleGroup> articlesGroups = new List<ArticleTitleGroup>();

            if (articles.Count() == 0)
                return articlesGroups;

            if (filter == ArchiveFilter.Alphabet)
            {
                var grouped = articles
                    .GroupBy(x => x.Title[0])
                    .OrderBy(x => x.Key)
                    .ToList();

                foreach (var group in grouped)
                {
                    articlesGroups.Add(new ArticleTitleGroup
                    {
                        Articles = group.ToList(),
                        GroupName = group.Key.ToString(),
                    });
                }
            }
            else if (filter == ArchiveFilter.Date)
            {
                var grouped = articles
                    .OrderByDescending(x => x.CreationDate)
                    .GroupBy(x => x.CreationDate.Year)
                    .ToList();

                foreach (var group in grouped)
                {
                    articlesGroups.Add(new ArticleTitleGroup
                    {
                        Articles = group.ToList(),
                        GroupName = group.Key.ToString(),
                    });
                }
            }

            return articlesGroups;
        }
    }
}
