using System.Collections.Generic;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Domain.MainModule.Contracts;
using AutoMapper;

namespace Agathas.Storefront.AppServices.Mapping
{
    public static class ProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(
            this IEnumerable<IProductAttribute> productAttributes,
            RefinementGroupings refinementGroupType)
        {
            var refinementGroup = new RefinementGroup
                                      {
                                          Name = refinementGroupType.ToString(),
                                          GroupId = (int) refinementGroupType,
                                          Refinements = Mapper.Map<IEnumerable<IProductAttribute>,
                                              IEnumerable<Refinement>>(productAttributes)
                                      };
            return refinementGroup;
        }
    }
}
