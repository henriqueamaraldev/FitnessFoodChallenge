namespace Repository.models
{
    public class PaginatedResult<T> where T : class
    {
        public int CurrentPage { get; set; }
        public long PageCount { get; set; }
        public int PageSize { get; set; }
        public IList<T> Results { get; set; } = new List<T>();

        public PaginatedResult(PaginatedRequest request, long totalDocuments, List<T> result)
        {
            CurrentPage = request.Page;
            int countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalDocuments / request.PageSize)));

            if (countPages < 1)
                countPages = 1;
            PageCount = countPages;
            PageSize = request.PageSize;
            Results = result != null ? result : this.Results;
        }
    }
}
