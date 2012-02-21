using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Presentation.Presenters.Views;

namespace Agathas.Storefront.Presentation.Presenters.Presenters
{
    public abstract class BasePresenter<TView> : IPresenter where TView : IView
    {
        protected BasePresenter(TView view)
        {
            View = view;
        }

        protected TView View { get; private set; }

        public abstract void OnViewInit();
        public abstract void OnViewLoad();
    }
}
