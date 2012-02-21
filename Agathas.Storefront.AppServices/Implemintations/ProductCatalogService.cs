using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Domain.MainModule.Contracts;
using Agathas.Storefront.Domain.MainModule.Entities;
using Agathas.Storefront.Domain.Specifications;

namespace Agathas.Storefront.AppServices.Implemintations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCatalogService(IProductTitleRepository productTitleRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            if (productTitleRepository == null) throw new ArgumentNullException("productTitleRepository");
            if (productRepository == null) throw new ArgumentNullException("productRepository");
            if (categoryRepository == null) throw new ArgumentNullException("categoryRepository");

            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        #region Implementation of IProductCatalogService

        public GetFeaturedProductsResponse GetFeaturedProducts()
        {
            throw new NotImplementedException();
        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            var response = new GetProductsByCategoryResponse();

            var specification =
                new DirectSpecification<Product>(product => product.ProductTitle.Category.Id == request.CategoryId);

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceHighToLow:
                    {
                        response.Products =
                            _productRepository.GetBySpec(specification).OrderByDescending(p => p.ProductTitle.Price) as
                            IEnumerable<ProductSummaryView>;
                        break;
                    }
                case ProductsSortBy.PriceLowToHigh:
                    {
                        response.Products =
                            _productRepository.GetBySpec(specification).OrderBy(p => p.ProductTitle.Price) as
                            IEnumerable<ProductSummaryView>;
                        break;
                    }
            }


            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            throw new NotImplementedException();
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
