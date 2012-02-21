using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Domain.MainModule.Entities;
using AutoMapper;

namespace Agathas.Storefront.AppServices.Mapping
{
    public static class ProductTitleMapper
    {
        public static IEnumerable<ProductSummaryView> ConvertToProductViews(this IEnumerable<ProductTitle> products)
        {
            return Mapper.Map<IEnumerable<ProductTitle>,
                IEnumerable<ProductSummaryView>>(products);
        }

        public static ProductView ConvertToProductDetailView(this ProductTitle product)
        {
            return Mapper.Map<ProductTitle, ProductView>(product);
        }
    }
}
