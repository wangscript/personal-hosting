using Agathas.Storefront.Infrastructure.Helpers;
using AutoMapper;

namespace Agathas.Storefront.AppServices.Formatters
{
    public class MoneyFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                var money = (decimal)context.SourceValue;
                return money.FormatMoney();
            }
            return context.SourceValue.ToString();
        }
    }
}
