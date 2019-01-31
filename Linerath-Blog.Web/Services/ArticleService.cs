using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Linerath_Blog.Web.Enums;
using Linerath_Blog.Web.Models;
using Linerath_Blog.DAL.Entities;
using System.Text;
using System.Globalization;

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

        public static void TruncateArticles(List<Article> source, int maxLinesCount = MAX_LINES_COUNT, int maxArticleLength = MAX_ARTICLE_LENGHT)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            for (int i = 0; i < source.Count(); ++i)
                source[i].Body = GetTruncatedString(source[i].Body, maxLinesCount);
        }

        public static void FormatArticle(String pathToBody, String pathToSummary, String title, DateTime creationDate)
        {
            if (!File.Exists(pathToBody) || !File.Exists(pathToSummary))
                return;

            String extension = pathToBody.Substring(pathToBody.IndexOf('.'));
            String pathToNewFile = pathToBody.Remove(pathToBody.LastIndexOf('.'));
            pathToNewFile += ". formatted" + extension;

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

            CultureInfo enUS = new CultureInfo("en-US");

            String result = $"(N'{title}', N{body.ToString()}, N{summary.ToString()}, '{creationDate.ToString("yyyyMMdd hh:mm:ss tt", enUS)}')";

            File.WriteAllText(pathToNewFile, result);

            //using (FileStream fs = new FileStream(pathToNewFile, FileMode.Create, FileAccess.Write))
            //{
            //    using (StreamWriter writer = new StreamWriter(fs))
            //    {
            //        bool first = true;
            //        foreach (String line in File.ReadLines(pathToBody))
            //        {
            //            String formattedLine = FormatLine(line, first);

            //            if (first)
            //                first = false;

            //            writer.Write(formattedLine);
            //        }
            //    }
            //}

        }

        private static String FormatLine(String line, bool first = true)
        {
            if (String.IsNullOrEmpty(line))
            {
                return (first)
                    ? "CHAR(13)"
                    : " + CHAR(13)";
            }
            else
            {
                line = line.Replace("'", "''");

                line = first
                    ? "'" + line + "'"
                    : "+ CHAR(13) + '" + line + "'";

                return line;
            }
        }

        public static void CalculateCategoriesCount(List<CategoryModel> categories, List<Article> allArticles)
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
