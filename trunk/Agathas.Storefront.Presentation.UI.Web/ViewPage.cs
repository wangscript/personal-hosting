using System;
using System.Web.UI;
using Agathas.Storefront.Presentation.Presenters;
using Agathas.Storefront.Presentation.Presenters.Views;

namespace Agathas.Storefront.Presentation.UI.Web
{
    public class ViewPage<TPresenter> : Page, IView where TPresenter : IPresenter
    {
        protected TPresenter Presenter { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Presenter = Global.IoCContainer.Resolve<TPresenter>();
            Presenter.OnViewInit(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Presenter.OnViewLoad();
        }
    }
}