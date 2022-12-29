namespace Repository.models
{
    public class PaginatedResult<T> where T : class
    {
        public int CurrentPage { get; set; }
        public long PageCount { get; set; }
        public int PageSize { get; set; }
        public IList<T> Results { get; set; } = new List<T>();

        public PaginatedResult(PaginatedRequest request, long totalPages, List<T> result)
        {
            CurrentPage = request.Page;
            PageCount = totalPages;
            PageSize = request.PageSize;
            Results = result;
        }
    }
}
