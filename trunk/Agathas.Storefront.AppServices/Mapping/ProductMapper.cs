using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Domain.MainModule.Contracts;
using Agathas.Storefront.Domain.MainModule.Entities;

namespace Agathas.Storefront.AppServices.Mapping
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateProductSearchResultFrom(
            this IEnumerable<Product> productsMatchingRefinement,
            GetProductsByCategoryRequest request)
        {
            var productSearchResultView =
                new GetProductsByCategoryResponse();
            var productsFound =
                productsMatchingRefinement.Select(p => p.ProductTitle).Distinct();
            productSearchResultView.SelectedCategory = request.CategoryId;
            productSearchResultView.NumberOfTitlesFound = productsFound.Count();
            productSearchResultView.TotalNumberOfPages =
                NoOfResultPagesGiven(request.NumberOfResultsPerPage,
                                     productSearchResultView.NumberOfTitlesFound);
            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);
            productSearchResultView.Products =
                CropProductListToSatisfyGivenIndex(request.Index,
                                                   request.NumberOfResultsPerPage, productsFound);
            return productSearchResultView;
        }

        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex,
                                                                                          int numberOfResultsPerPage,
                                                                                          IEnumerable<ProductTitle>
                                                                                              productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1)*numberOfResultsPerPage;
                return productsFound.Skip(numToSkip)
                    .Take(numberOfResultsPerPage).ConvertToProductViews();
            }

            return productsFound.Take(numberOfResultsPerPage).ConvertToProductViews();
        }

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;

            return (numberOfTitlesFound/numberOfResultsPerPage) +
                   (numberOfTitlesFound%numberOfResultsPerPage);
        }

        private static IEnumerable<RefinementGroup> GenerateAvailableProductRefinementsFrom(
            IEnumerable<ProductTitle> productsFound)
        {
            var brandsRefinementGroup = productsFound
                .Select(p => p.Brand).Distinct().ToList()
                .ConvertAll(b => (IProductAttribute) b)
                .ConvertToRefinementGroup(RefinementGroupings.Brand);
            var colorsRefinementGroup = productsFound
                .Select(p => p.Color).Distinct().ToList()
                .ConvertAll(c => (IProductAttribute) c)
                .ConvertToRefinementGroup(RefinementGroupings.Color);

            var sizesRefinementGroup = (from p in productsFound
                                        from si in p.Products
                                        select si.Size).Distinct().ToList()
                .ConvertAll(s => (IProductAttribute) s).ConvertToRefinementGroup(
                    RefinementGroupings.Size);

            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);
            return refinementGroups;
        }
    }
}
