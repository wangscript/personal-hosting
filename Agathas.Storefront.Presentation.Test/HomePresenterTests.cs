using System;
using System.Linq;
using System.Collections.Generic;
using Agathas.Storefront.AppServices.Contracts;
using Agathas.Storefront.AppServices.Messaging.ProductCatalog;
using Agathas.Storefront.AppServices.ViewModels;
using Agathas.Storefront.Presentation.Presenters;
using Agathas.Storefront.Presentation.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Agathas.Storefront.Presentation.Test
{
  
    [TestClass]
    public class HomePresenterTests
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullArgumentException_Throw()
        {
            new HomePresenter(null, null);
        }

        [TestMethod]
        public void OnViewLoad_ViewIsPostBackSetTrue_NoExecution()
        {
            var view = MockRepository.GenerateMock<IHomePageView>();
            var service = MockRepository.GenerateMock<IProductCatalogService>();
            view.Expect(x => x.IsPostBack).Return(true);
            var presender = new HomePresenter(view, service);

            presender.OnViewLoad();

            Assert.IsNull(view.Products);
            Assert.IsNull(view.Categories);
        }

        [TestMethod]
        public void OnViewLoad_ViewIsPostBackSetFalse_ExecutionSuccess()
        {
            var view = MockRepository.GenerateMock<IHomePageView>();
            var service = MockRepository.GenerateMock<IProductCatalogService>();
            view.Expect(x => x.IsPostBack).Return(false);
 
            service.Expect(x => x.GetAllCategories()).Return(new GetAllCategoriesResponse
                                                                 {
                                                                     Categories =
                                                                         new List<CategoryView>()
                                                                             {
                                                                                 new CategoryView {Id = 12, Name = "Test"},
                                                                                 new CategoryView {Id = 45, Name = "Test2"}
                                                                             }
                                                                 });
            service.Expect(x => x.GetFeaturedProducts()).Return(new GetFeaturedProductsResponse
                                                                    {
                                                                        Products =
                                                                            new List<ProductSummaryView>
                                                                                {
                                                                                    new ProductSummaryView
                                                                                        {
                                                                                            Id = 3,
                                                                                            BrandName = "TestBrand",
                                                                                            Name = "TestName",
                                                                                            Price = "34"
                                                                                        }
                                                                                }
                                                                    });
            var presender = new HomePresenter(view, service);

            presender.OnViewLoad();

            Assert.IsNotNull(view.Products);
            Assert.IsNotNull(view.Categories);
            Assert.AreEqual(2, view.Categories.Count());
            Assert.AreEqual(1,view.Products.Count());
        }
    }
}
