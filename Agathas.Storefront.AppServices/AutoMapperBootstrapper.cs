using Agathas.Storefront.AppServices.Formatters;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Domain.MainModule.Contracts;
using Agathas.Storefront.Domain.MainModule.Entities;
using AutoMapper;

namespace Agathas.Storefront.AppServices
{
    public class AutoMapperBootstrapper
    {
        public static void ConfigureAutoMapper()
        {
            // Product Title and Product
            Mapper.CreateMap<ProductTitle, ProductSummaryView>();
            Mapper.CreateMap<ProductTitle, ProductView>();
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();

            // Category
            Mapper.CreateMap<Category, CategoryView>();

            // IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();

            // Global Money Formatter
            Mapper.AddFormatter<MoneyFormatter>();
        }
    }
}
