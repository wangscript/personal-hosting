using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.Presentation.Presenters.Views
{
    public interface IProductSearchResultView : IBaseProductCatalogView
    {
        string SelectedCategoryName { get; set; }
        int SelectedCategory { get; set; }
        IEnumerable<RefinementGroup> RefinementGroups { get; set; }
        int NumberOfTitlesFound { get; set; }
        int TotalNumberOfPages { get; set; }
        int CurrentPage { get; set; }
        IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
