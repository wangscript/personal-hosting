using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Domain.MainModule.Entities;
using AutoMapper;

namespace Agathas.Storefront.AppServices.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViews(this IEnumerable<Category> categories)
        {
            return Mapper.Map<IEnumerable<Category>,
            IEnumerable<CategoryView>>(categories);
        }
    }
}
