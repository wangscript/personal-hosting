using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Views
{
    public interface IProductDetailView : IProductCatalogView
    {
        ProductView Product { get; set; }
    }
}
