using System.Text.Json;

namespace Northwind_Backend.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _dataContext;

        public ProductsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> IsProdctIdTaken(int productId)
        {
            var product = await _dataContext.Products.Where(u => u.Id == productId).AnyAsync();
            if (product)
                return false;

            return true;
        }
        public async Task<bool> AddProduct(Product product)
        {
            _dataContext.Products.Add(product);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            if (product != null)
                _dataContext.Products.Remove(product);
            else
                return false;

            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetOneProductAsync(int id)
        {

            var product = await _dataContext.Products.FindAsync(id);
            if(product == null)
                return null;
            return product;
        }

        public async Task<bool> UpdateProduct(int id, Product newProduct)
        {
            var prod = await _dataContext.Products.FindAsync(id);

            if (prod == null)
                return false;

            prod.Name = newProduct.Name;
            prod.Price = newProduct.Price;
            prod.Stock = newProduct.Stock;
            prod.ImageName = newProduct.ImageName;
            return await _dataContext.SaveChangesAsync()>0;
        }

    }
}
