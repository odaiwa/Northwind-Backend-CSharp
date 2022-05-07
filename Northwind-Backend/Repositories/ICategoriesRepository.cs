
namespace Northwind_Backend.Repositories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(int id, Category newCategory);
        Task<bool> DeleteCategoryByIdAsync(int id);
    }
}
