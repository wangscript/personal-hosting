using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.AppServices.Messaging.ProductCatalog
{
    public class GetFeaturedProductsResponse
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
