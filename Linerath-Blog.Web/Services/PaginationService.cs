using Linerath_Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linerath_Blog.Web.Services
{
    public static class PaginationService
    {
        public const int PAGE_SIZE = 1;
        public const int MAX_VISIBLE_PAGES = 3;

        public static IEnumerable<T> Paginate<T>(IEnumerable<T> data, int page, int pageSize = PAGE_SIZE)
        {
            if (data == null) throw new ArgumentNullException("data");
            if (page < 0) throw new ArgumentException("page < 0");
            if (pageSize <= 0) throw new ArgumentException("pageSize must be more than 0");

            return data.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static int GetTotalPages<T>(IEnumerable<T> data, int pageSize = PAGE_SIZE)
        {
            if (data == null) throw new ArgumentNullException("data");
            if (pageSize <= 0) throw new ArgumentException("pageSize must be more than 0");

            int pages = (int)Math.Ceiling((decimal)data.Count() / pageSize);

            return pages;
        }

        public static PaginationModel GetDefaultPaginationModel<T>(
            IEnumerable<T> data,
            int page,
            int pageSize = PAGE_SIZE,
            int maxVisiblePages = MAX_VISIBLE_PAGES
            )
        {
            if (pageSize <= 0) throw new ArgumentException("pageSize must be more than 0");
            if (maxVisiblePages <= 0) throw new ArgumentException("maxVisiblePages must be more than 0");

            PaginationModel model = new PaginationModel
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = GetTotalPages(data),
                MaxVisiblePages = maxVisiblePages,
            };

            return model;
        }

        /// <summary>
        /// Getting first visible page on pagination panel.
        /// </summary>
        /// <param name="page">Current page.</param>
        /// <param name="totalPages">Total pages.</param>
        /// <returns>First visible page.</returns>
        public static int GetPaginationFirstPage(
            int page,
            int totalPages,
            int maxVisiblePages = MAX_VISIBLE_PAGES
            )
        {
            if (page <= 0) throw new ArgumentException("page must be more than 0");
            if (totalPages <= 0) throw new ArgumentException("totalPages must be more than 0");
            if (maxVisiblePages <= 0) throw new ArgumentException("maxVisiblePages must be more than 0");

            if (totalPages <= maxVisiblePages || page == 1)
                return 1;

            if (page == totalPages)
                return page - maxVisiblePages + 1;

            if (maxVisiblePages % 2 == 0)
                --maxVisiblePages;

            int firstPage = page - (int)Math.Floor((decimal)maxVisiblePages / 2);

            return firstPage;
        }
        /// <summary>
        /// Getting last visible page on pagination panel.
        /// </summary>
        /// <param name="page">Current page.</param>
        /// <param name="totalPages">Total pages.</param>
        /// <returns>Last visible page.</returns>
        public static int GetPaginationLastPage(
            int page,
            int totalPages,
            int maxVisiblePages = MAX_VISIBLE_PAGES
            )
        {
            if (page <= 0) throw new ArgumentException("page must be more than 0");
            if (totalPages <= 0) throw new ArgumentException("totalPages must be more than 0");
            if (maxVisiblePages <= 0) throw new ArgumentException("maxVisiblePages must be more than 0");

            if (totalPages <= maxVisiblePages || page == totalPages)
                return totalPages;

            if (page == 1)
                return maxVisiblePages;

            int lastPage = page + (int)Math.Floor((decimal)maxVisiblePages / 2);

            return lastPage;
        }

    }
}