using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Views
{
    public interface IProductCatalogView : IView
    {
        IEnumerable<CategoryView> Categories { get; set; }
    }
}
