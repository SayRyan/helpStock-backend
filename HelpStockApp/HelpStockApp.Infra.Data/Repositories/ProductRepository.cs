using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Interfaces;
using HelpStockApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpStockApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext productContext)
        {
            _productContext = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            var product = await _productContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Product> RemoveProduct(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
