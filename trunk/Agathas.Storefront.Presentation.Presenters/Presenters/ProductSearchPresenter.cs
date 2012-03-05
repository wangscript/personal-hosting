using System;
using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.Infrastructure.CrossCutting.Configuration;
using Agathas.Storefront.Presentation.Views;

namespace Agathas.Storefront.Presentation.Presenters
{
    public class ProductSearchPresenter : ProductCatalogBasePresenter<IProductSearchResultView>
    {
        private readonly IApplicationConfiguration _configuration;

        public ProductSearchPresenter(IProductCatalogService service, IProductSearchResultView view,
                                IApplicationConfiguration configuration)
            : base(view, service)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            _configuration = configuration;
        }

       
        private void SearchProductResultViewFrom()
        {
            var productSearchRequest = GenerateInitialProductSearchRequest();
            var response = ProductCatalogService.GetProductsByCategory(productSearchRequest);

            View.Categories = GetCategories();
            View.CurrentPage = response.CurrentPage;
            View.NumberOfTitlesFound = response.NumberOfTitlesFound;
            View.Products = response.Products;
            View.RefinementGroups = response.RefinementGroups;
            View.SelectedCategory = response.SelectedCategory;
            View.SelectedCategoryName = response.SelectedCategoryName;
            View.TotalNumberOfPages = response.TotalNumberOfPages;
        }

        private GetProductsByCategoryRequest GenerateInitialProductSearchRequest()
        {
            return new GetProductsByCategoryRequest
                       {
                           NumberOfResultsPerPage = _configuration.NumberOfResultsPerPage,
                           CategoryId = View.CategoryId,
                           Index = 1,
                           SortBy = ProductsSortBy.PriceHighToLow
                       };
        }
    }
}
