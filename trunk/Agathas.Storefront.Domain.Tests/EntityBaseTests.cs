using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Agathas.Storefront.Domain.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agathas.Storefront.Domain.Tests
{
    /// <summary>
    /// Summary description for EntityBaseTests
    /// </summary>
    [TestClass]
    public class EntityBaseTests
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
        public void IsEqualsEntities()
        {
           //Preparation
            MockTestEntity testEntityOne = new MockTestEntity();
            MockTestEntity testEntityTwo = new MockTestEntity();
            testEntityOne.Id = 4;
            testEntityTwo.Id = 4;

            //Action
            bool result = testEntityOne.Equals(testEntityTwo);

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(testEntityOne == testEntityTwo);
        }

        [TestMethod]
        public void IsNotEqualsEntities()
        {
            //Preparation
            MockTestEntity testEntityOne = new MockTestEntity();
            MockTestEntity testEntityTwo = new MockTestEntity();
            testEntityOne.Id = 6;
            testEntityTwo.Id = 4;

            //Action
            bool result = testEntityOne.Equals(testEntityTwo);

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(testEntityOne != testEntityTwo);
        }

        [TestMethod]
        public  void BrokenRuleNotNullAndIsAdded()
        {
            //Preparation
            MockTestEntity testEntityOne = new MockTestEntity();

            //Action
            IEnumerable<BusinessRule> result = testEntityOne.GetBrokenRules();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("TestProp", result.First().Property);
            Assert.AreEqual("For Tests Causes", result.First().Rule);

        }
    }
}
