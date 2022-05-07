using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryController(DataContext dataContext, ICategoriesRepository categoriesRepository)
        {
            _dataContext = dataContext;
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoriesRepository.GetAllCategoriesAsync();
                if (categories.Count() == 0)
                    return Ok("no categories available");
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetProductById(int id)
        {
            try
            {
                var categoriy = await _categoriesRepository.GetCategoryByIdAsync(id);
                if (categoriy == null)
                    return BadRequest("Category doesn't exist");
                return Ok(categoriy);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            try
            {
                var addedCategory = await _categoriesRepository.AddCategoryAsync(category);
                if (addedCategory == null)
                    return BadRequest("try again");
                return Ok(addedCategory);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Category category)
        {
            try
            {
                var Updated = await _categoriesRepository.UpdateCategoryAsync(id, category);
                if (!Updated)
                    return BadRequest("unable to update category");
                return Ok(await _categoriesRepository.GetCategoryByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var category = await _categoriesRepository.DeleteCategoryByIdAsync(id);
                if (category)
                    return Ok("category deleted successfully");
                return BadRequest($"Problem deleting category with id {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
