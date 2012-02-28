using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.Presentation.Views;

namespace Agathas.Storefront.Presentation.Presenters
{
    public class ProductCatalogPresenter : ProductCatalogBasePresenter<IProductCatalogView>
    {
        public ProductCatalogPresenter(IProductCatalogView view, IProductCatalogService service)
            : base(view, service)
        {
        }

        #region Overrides of BasePresenter<IBaseProductCatalogView>

        public override void OnViewLoad()
        {
            if (View.IsPostBack) return;

            View.Categories = GetCategories();
            View.DataBind();
        }

        #endregion
    }
}