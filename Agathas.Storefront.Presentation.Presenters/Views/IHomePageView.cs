using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Views
{
    public interface IHomePageView : IProductCatalogView
    {
        IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
