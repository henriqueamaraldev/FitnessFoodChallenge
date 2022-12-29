namespace Repository.models
{
    public interface PaginatedRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
