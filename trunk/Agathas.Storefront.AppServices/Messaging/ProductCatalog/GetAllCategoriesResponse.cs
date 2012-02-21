using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;

namespace Agathas.Storefront.AppServices.Messaging.ProductCatalog
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
