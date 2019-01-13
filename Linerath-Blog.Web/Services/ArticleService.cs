using System;
using System.Linq;
using System.Collections.Generic;
using Linerath_Blog.Web.Enums;
using Linerath_Blog.Web.Models;
using Linerath_Blog.DAL.Entities;

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

        public static void TrucateArticles(List<Article> source, int maxLinesCount = MAX_LINES_COUNT, int maxArticleLength = MAX_ARTICLE_LENGHT)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            for (int i = 0; i < source.Count(); ++i)
                source[i].Body = ArticleService.GetTruncatedString(source[i].Body, maxLinesCount);
        }

        public static String GetTruncatedString(String source, int maxLinesCount = MAX_LINES_COUNT, int maxArticleLength = MAX_ARTICLE_LENGHT)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (maxLinesCount < 0)
                throw new ArgumentException("maxLinesCount must be more or equal to 0");
            if (maxArticleLength < 0)
                throw new ArgumentException("maxArticleLength must be more or equal to 0");

            if (maxLinesCount == 0 || maxArticleLength == 0)
                return "...";

            if (source.Length > maxArticleLength)
            {
                String truncated = source.Remove(maxArticleLength);
                if (truncated.LastIndexOf(' ') >= 0)
                    truncated = truncated.Remove(truncated.LastIndexOf(' '));
                truncated += "...";

                return truncated;
            }
            else
            {
                String[] lines = source.Split('\n');

                if (lines.Count() > maxLinesCount)
                {
                    lines = lines.Take(maxLinesCount).ToArray();
                    String truncated = String.Join("\n", lines);

                    return truncated;
                }
                else
                    return source;
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