using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.Presentation.Views;

namespace Agathas.Storefront.Presentation.Presenters
{
    public class HomePresenter : ProductCatalogBasePresenter<IHomePageView>
    {
        public HomePresenter(IHomePageView view, IProductCatalogService service)
            : base(view, service)
        {
           
        }

        #region Overrides of BasePresenter<IHomePageView>

        public override void OnViewLoad()
        {
            if (View.IsPostBack) return;

            var responseProducts = ProductCatalogService.GetFeaturedProducts();

            View.Categories = GetCategories();
            View.Products = responseProducts.Products;
            View.DataBind();
        }

        #endregion
    }
}
