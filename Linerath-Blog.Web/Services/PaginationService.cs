using Linerath_Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linerath_Blog.Web.Services
{
    public static class PaginationService
    {
        public const int PAGE_SIZE = 5;
        public const int MAX_VISIBLE_PAGES = 10;

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
        /// Getting first and last visible pages on pagination panel.
        /// </summary>
        /// <param name="page">Current page.</param>
        /// <param name="totalPages">Total pages.</param>
        /// <returns>First and last visible pages.</returns>
        public static (int, int) GetBorderPages(
            int page,
            int totalPages,
            int maxVisiblePages = MAX_VISIBLE_PAGES
            )
        {
            if (page <= 0 || totalPages <= 0 || maxVisiblePages <= 0)
                return (-1, -1);

            int firstPage = -1, lastPage = -1;

            if (totalPages <= maxVisiblePages)
            {
                firstPage = 1;
                lastPage = totalPages;
            }
            else if (page == 1)
            {
                firstPage = 1;
                lastPage = maxVisiblePages;
            }
            else if (page == totalPages)
            {
                firstPage = totalPages - maxVisiblePages + 1;
                lastPage = totalPages;
            }


            if (firstPage == -1)
            {
                if (maxVisiblePages % 2 == 0)
                    firstPage = page - (int)Math.Floor((decimal)(maxVisiblePages - 1) / 2);
                else
                    firstPage = page - (int)Math.Floor((decimal)maxVisiblePages / 2);

                if (firstPage < 1)
                {
                    firstPage = 1;
                    lastPage = maxVisiblePages;
                }

                if (lastPage == -1)
                {
                    lastPage = page + (int)Math.Floor((decimal)maxVisiblePages / 2);
                    if (lastPage > totalPages)
                    {
                        firstPage = totalPages - maxVisiblePages + 1;
                        lastPage = totalPages;
                    }
                }
            }

            return (firstPage, lastPage);
        }
    }
}