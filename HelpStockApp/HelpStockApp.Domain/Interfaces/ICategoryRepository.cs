using HelpStockApp.Domain.Entities;

namespace HelpStockApp.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetById(int? id);

        Task<Category> CreateCategory(Category category);

        Task<Category> UpdateCategory(Category category);

        Task<Category> RemoveCategory(Category category);
    }
}
