

namespace Northwind_Backend.Repositories
{
    public interface IProductsRepository
    {
        Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync();
        Task<ActionResult<Product>> GetOneProductAsync(int id);
        Task AddProduct(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProduct(Product newProduct);


    }
}
