using System;
using System.Collections.Generic;
using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Presentation.Presenters.Views;

namespace Agathas.Storefront.Presentation.Presenters
{
    public abstract class ProductCatalogBasePresenter<TView> : BasePresenter<TView> where TView : class, IView
    {
        private readonly IProductCatalogService _service;

        protected ProductCatalogBasePresenter(TView view, IProductCatalogService service)
            : base(view)
        {
            if (service == null) throw new ArgumentNullException("service");

            _service = service;
        }

        protected IProductCatalogService ProductCatalogService
        {
            get { return _service; }
        }

        protected IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response =
            _service.GetAllCategories();
            return response.Categories;
        }

        public override void OnViewInit()
        {
            
        }

        public override void OnViewLoad()
        {
            
        }
    }
}
