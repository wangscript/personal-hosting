using Agathas.Storefront.AppServices.Messaging.ProductCatalog;

namespace Agathas.Storefront.AppServices.Contracts
{
    public interface IProductCatalogService
    {
        GetFeaturedProductsResponse GetFeaturedProducts();
        GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
        GetAllCategoriesResponse GetAllCategories();
    }
}
