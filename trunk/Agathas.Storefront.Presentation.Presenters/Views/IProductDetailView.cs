using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Presenters.Views
{
    public interface IProductDetailView : IBaseProductCatalogView
    {
        ProductView Product { get; set; }
    }
}
