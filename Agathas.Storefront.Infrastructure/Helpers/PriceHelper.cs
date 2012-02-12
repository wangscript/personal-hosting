namespace Agathas.Storefront.Infrastructure.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return string.Format("${0}", price);    
        }
    }
}
