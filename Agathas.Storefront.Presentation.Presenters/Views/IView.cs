namespace Agathas.Storefront.Presentation.Presenters.Views
{
    public interface IView
    {
        bool IsPostBack { get; }
        void DataBind();
    }
}
