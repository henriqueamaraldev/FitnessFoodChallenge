using Application.Interfaces;
using Repository.models;
using Repository.services;

namespace Application.Services
{
    public class ProductsServices : IProductsServices
    {
        ProductsCollection _productsCollection;
        public ProductsServices(ProductsCollection productsCollection)
        {
            _productsCollection = productsCollection;
        }
        public async Task<Product> GetProductsByIdAsync(long id)
        {
            var product = await _productsCollection.GetByIdAsync(id);

            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _productsCollection.GetAllAsync();

            return products;
        }
    }
}
