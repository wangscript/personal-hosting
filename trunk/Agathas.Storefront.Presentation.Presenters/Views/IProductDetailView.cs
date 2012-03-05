using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Views
{
    public interface IProductDetailView : IProductCatalogView
    {
        int ProductId { get; }
        ProductView Product { get; set; }
    }
}
