using System;
using System.Linq;
using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.AppServices.Mapping;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.AppServices.Mapping;
using Agathas.Storefront.Domain.MainModule.Contracts;
using Agathas.Storefront.Domain.MainModule.Entities;
using Agathas.Storefront.Domain.Specifications;

namespace Agathas.Storefront.AppServices.Implementations
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
            return new GetFeaturedProductsResponse
                       {
                           Products =
                               _productTitleRepository.GetAll().OrderByDescending(title => title.Price).Take(6).
                               ConvertToProductViews()
                       };

        }

        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new GetProductsByCategoryResponse();

            var specification =
                new DirectSpecification<Product>(product => product.ProductTitle.Category.Id == request.CategoryId);

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceHighToLow:
                    {
                        response =
                            _productRepository.GetBySpec(specification).OrderByDescending(p => p.ProductTitle.Price).
                                CreateProductSearchResultFrom(request);
                        break;
                    }
                case ProductsSortBy.PriceLowToHigh:
                    {
                        response =
                            _productRepository.GetBySpec(specification).OrderBy(p => p.ProductTitle.Price).
                                CreateProductSearchResultFrom(request);
                        break;
                    }
            }

            var singleCategory =
                _categoryRepository.GetBySpec(
                    new DirectSpecification<Category>(category => category.Id == request.CategoryId)).SingleOrDefault();

            if (singleCategory != null)
                response.SelectedCategoryName = singleCategory.Name;

            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new GetProductResponse();
            var singleProduct = _productRepository.GetBySpec(new DirectSpecification<Product>(product => product.Id == request.ProductId)).SingleOrDefault();

            if (singleProduct != null)
                response.Product = singleProduct.ProductTitle.ConvertToProductDetailView();

            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            return new GetAllCategoriesResponse
                       {
                           Categories = _categoryRepository.GetAll().ConvertToCategoryViews()
                       };
        }

        #endregion
    }
}
