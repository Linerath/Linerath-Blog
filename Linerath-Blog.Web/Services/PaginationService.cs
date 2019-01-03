using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Linerath_Blog.Web.Services
{
    public static class PaginationService
    {
        private static int pageSize = 2;

        public static IEnumerable<T> Paginate<T>(IEnumerable<T> data, int page)
        {
            if (data == null) throw new ArgumentNullException("data");
            if (page < 0) throw new ArgumentException("page < 0");

            return data.Skip((page - 1) * PageSize).Take(PageSize);
        }

        public static int GetTotalPages<T>(IEnumerable<T> data)
        {
            if (data == null) throw new ArgumentNullException("data");

            int pages = (int)Math.Ceiling((decimal)data.Count() / PageSize);

            return pages;
        }

        public static int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (pageSize <= 0)
                    throw new ArgumentException("pageSize must be more than 0");

                pageSize = value;
            }
        }
    }
}