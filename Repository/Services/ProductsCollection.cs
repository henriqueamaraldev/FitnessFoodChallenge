using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repository.models;
using Repository.Models.Interfaces;
using Repository.settings;
using System.Linq.Expressions;

namespace Repository.services
{
    public class ProductsCollection : IProductsCollection
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductsCollection(IOptions<ProductDbConfigs> productServices)
        {
            var mongoClient = new MongoClient(productServices.Value.ConnString);
            var mongoDatabase = mongoClient.GetDatabase(productServices.Value.Name);
            _productCollection = mongoDatabase.GetCollection<Product>("Products");
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PaginatedResult<Product>> GetPaginatedAsync(PaginatedRequest request)
        {
            var result = await _productCollection.Find(x => true)
                .Skip((request.Page - 1) * request.PageSize)
                .Limit(request.PageSize)
                .ToListAsync();
            var count = _productCollection.CountDocuments(x => true);
            return new PaginatedResult<Product>(request, count, result);
        }

        public async Task<bool> ProductExists(string barCode)
        {
            var product = await _productCollection.Find(x => x.BarCode == barCode).FirstOrDefaultAsync();

            if(product == null)
            {
                return false;
            }

            return true;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var oldProduct = await _productCollection.Find(x => x.BarCode == product.BarCode).FirstOrDefaultAsync();

            Expression<Func<Product, bool>> filter = x => x.Id.Equals(product.Id);

            product.Imported_at = oldProduct.Imported_at;

            await _productCollection.FindOneAndReplaceAsync<Product>(filter, product);
        }
        public async Task AddProductAsync(Product product)
        {
            await _productCollection.InsertOneAsync(product);
        }
    }
}
