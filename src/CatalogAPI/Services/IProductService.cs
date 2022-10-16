namespace CatalogAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product>? GetAllProducts();
        Product? GetProductById(long productId);
    }
}