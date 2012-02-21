using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Presenters.Views
{
    public interface IHomePageView : IBaseProductCatalogView
    {
        IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
