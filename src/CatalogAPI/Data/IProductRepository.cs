namespace CatalogAPI.Data
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(long productId);
    }
}