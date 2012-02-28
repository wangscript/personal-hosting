using System;
using Agathas.Storefront.Presentation.Presenters.Views;

namespace Agathas.Storefront.Presentation.Presenters
{
    public abstract class BasePresenter<TView> : IPresenter where TView : class, IView
    {
        protected BasePresenter(TView view)
        {
            if (view == null) throw new ArgumentNullException("view");

            View = view;
        }

        protected TView View { get; private set; }

        public abstract void OnViewInit();
        public abstract void OnViewLoad();
    }
}
