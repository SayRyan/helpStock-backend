using HelpStockApp.Domain.Entities;

namespace HelpStockApp.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetById(int? id);

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<Product> RemoveProduct(Product product);
    }
}
