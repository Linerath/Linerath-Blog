namespace Linerath_Blog.Web.Models
{
    public class PaginationModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int MaxVisiblePages { get; set; }
    }
}