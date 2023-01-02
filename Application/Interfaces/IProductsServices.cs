using MongoDB.Bson;
using Repository.models;

namespace Application.Interfaces
{
    public interface IProductsServices
    {
        Task<Product> GetProductsByIdAsync(string id);
        Task<PaginatedResult<Product>> GetPaginatedProductsAsync(PaginatedRequest request);
    }
}
