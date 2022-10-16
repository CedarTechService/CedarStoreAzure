namespace CatalogAPI.Services
{
    public interface IProductService
    {
        IEnumerable<ProductReadDto>? GetAllProducts();
        ProductReadDto? GetProductById(long productId);
    }
}