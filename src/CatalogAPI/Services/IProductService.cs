namespace CatalogAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}