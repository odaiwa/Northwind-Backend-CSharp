using System.Reflection;

namespace Northwind_Backend.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _dataContext;

        public CategoriesRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _dataContext.Categories.Add(category);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                var id = category.Id;
                return await _dataContext.Categories.FindAsync(id);
            }
            return null;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            if (category != null)
                _dataContext.Categories.Remove(category);
            else
                return false;

            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            if (category == null)
                return null;

            return category;
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category newCategory)
        {
            var category = await _dataContext.Categories.FindAsync(id);

            if (category == null)
                return false;

            category.Description = newCategory.Description;
            category.Name = newCategory.Name;
            if (newCategory.ImageName != null)
                category.ImageName = newCategory.ImageName;

            //_dataContext.Update<Category>(newCategory);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
