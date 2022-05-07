namespace Northwind_Backend.Repositories
{
    public interface IProductsRepository
    {
        Task<bool> IsProdctIdTaken(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetOneProductAsync(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateProduct(int id, Product newProduct);
    }
}
