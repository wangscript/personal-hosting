using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.Presentation.Views;

namespace Agathas.Storefront.Presentation.Presenters
{
    public class ProductDetailsPresenter : ProductCatalogBasePresenter<IProductDetailView>
    {
        public ProductDetailsPresenter(IProductDetailView view, IProductCatalogService service)
            : base(view, service)
        {
        }

        public override void OnViewLoad()
        {
            base.OnViewLoad();
            if (View.IsPostBack) return;

            var request = new GetProductRequest {ProductId = View.ProductId};
            var response = ProductCatalogService.GetProduct(request);

            View.Product = response.Product;
            View.Categories = GetCategories();
        }
    }
}
