using System;
using System.Collections.Generic;
using System.Web.UI;
using Agathas.Storefront.Presentation.Presenters;
using Agathas.Storefront.Presentation.Presenters.Views;

namespace Agathas.Storefront.Presentation.UI.Web
{
    public class ViewPage<TPresenter> : Page, IView where TPresenter : IPresenter
    {
        private const string ViewNameParameter = "view";

        protected TPresenter Presenter { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            var paramsValue = new Dictionary<string, object> {{ViewNameParameter, this}};
            Presenter = Global.IoCContainer.Resolve<TPresenter>(paramsValue);
            Presenter.OnViewInit(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Presenter.OnViewLoad();
        }
    }
}