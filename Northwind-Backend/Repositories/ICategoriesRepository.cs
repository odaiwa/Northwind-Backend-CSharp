
namespace Northwind_Backend.Repositories
{
    public interface ICategoriesRepository
    {
        Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync();
        Task<ActionResult<Category>> GetCategoryByIdAsync(int id);
        Task<ActionResult> AddCategoryAsync(Employee employee);
        Task<ActionResult> UpdateCategoryAsync(Employee employee);
        Task<ActionResult> DeleteCategoryByIdAsync(int id);
    }
}
