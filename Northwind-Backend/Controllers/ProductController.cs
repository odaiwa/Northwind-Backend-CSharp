using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind_Backend.Repositories;

namespace Northwind_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet("/")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var products = await productsRepository.GetAllProductsAsync();
                if (products.Count() == 0)
                    return Ok("no products available");
                return Ok(await productsRepository.GetAllProductsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Product>> GetProdductById(int id)
        {
            try
            {
                var product = await productsRepository.GetOneProductAsync(id);
                if (product == null)
                    return BadRequest("Product doesn't exist");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("/")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            try
            {
                var addedProduct = await productsRepository.AddProduct(product);
                if (!addedProduct)
                    return BadRequest("try again");
                return Ok(product);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPut("/{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            try
            {
                var Updated = await productsRepository.UpdateProduct(id, product);
                if (!Updated)
                    return BadRequest("unable to update product");
                return Ok(await productsRepository.GetOneProductAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var prod = await productsRepository.DeleteProductAsync(id);
                if (prod)
                    return Ok("product deleted successfully");
                return BadRequest($"Problem deleting Product with id {id}");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
