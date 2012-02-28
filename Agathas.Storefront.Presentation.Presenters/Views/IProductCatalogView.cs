using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Presentation.Presenters.Views;

namespace Agathas.Storefront.Presentation.Views
{
    public interface IProductCatalogView : IView
    {
        IEnumerable<CategoryView> Categories { get; set; }
    }
}
