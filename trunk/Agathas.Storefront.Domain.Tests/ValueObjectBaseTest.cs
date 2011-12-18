using Agathas.Storefront.Domain;
using Agathas.Storefront.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Agathas.Storefront.Domain.Tests.Mocks;

namespace Agathas.Storefront.Domain.Tests
{
    
    
    /// <summary>
    ///This is a test class for ValueObjectBaseTest and is intended
    ///to contain all ValueObjectBaseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ValueObjectBaseTest
    {

        /// <summary>
        ///A test for AddBrokenRule
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Agathas.Storefront.Domain.dll")]
        public void AddBrokenRuleTest()
        {
            PrivateObject param0 = new PrivateObject((ValueObjectBase) CreateValueObjectBase());
            ValueObjectBase_Accessor target = new ValueObjectBase_Accessor(param0); // TODO: Initialize to an appropriate value
            BusinessRule businessRule = new BusinessRule("Prop1","Test1"); // TODO: Initialize to an appropriate value
            
            target.AddBrokenRule(businessRule);
            
            Assert.IsNotNull(target._businessRules);
            Assert.AreEqual(1, target._businessRules.Count);
            Assert.AreEqual("Prop1", target._businessRules[0].Property);
            Assert.AreEqual("Test1", target._businessRules[0].Rule);
        }

        internal virtual ValueObjectBase CreateValueObjectBase()
        {
            // TODO: Instantiate an appropriate concrete class.
            ValueObjectBase target = new MockValueObject();
            return target;
        }

        /// <summary>
        ///A test for ThrowExceptionIfInvalid
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ValueObjectIsInvalidException))]
        public void ThrowExceptionIfInvalidTest()
        {
            ValueObjectBase target = CreateValueObjectBase();
            target.ThrowExceptionIfInvalid();
        }
    }
}
