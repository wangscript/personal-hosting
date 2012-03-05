namespace Agathas.Storefront.Presentation.Views
{
    public interface IView
    {
        bool IsPostBack { get; }
        void DataBind();
    }
}
