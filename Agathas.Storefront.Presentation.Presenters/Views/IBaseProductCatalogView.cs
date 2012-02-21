using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Presenters.Views
{
    public interface IBaseProductCatalogView : IView
    {
        IEnumerable<CategoryView> Categories { get; set; }
    }
}
