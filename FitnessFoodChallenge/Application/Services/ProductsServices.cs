using Application.Interfaces;
using Repository.models;
using Repository.Models.Interfaces;
using Repository.services;

namespace Application.Services
{
    public class ProductsServices : IProductsServices
    {
        IProductsCollection _productsCollection;
        public ProductsServices(IProductsCollection productsCollection)
        {
            _productsCollection = productsCollection;
        }
        public async Task<Product> GetProductsByIdAsync(string id)
        {
            var product = await _productsCollection.GetByIdAsync(id);

            return product;
        }

        public async Task<PaginatedResult<Product>> GetPaginatedProductsAsync(PaginatedRequest request)
        {
            var products = await _productsCollection.GetPaginatedAsync(request);

            return products;
        }
    }
}
