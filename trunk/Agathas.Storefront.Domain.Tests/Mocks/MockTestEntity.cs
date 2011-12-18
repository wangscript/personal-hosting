using Agathas.Storefront.Domain.Entities;

namespace Agathas.Storefront.Domain.Tests.Mocks
{
    internal class MockTestEntity : EntityBase<int>
    {
        protected override void Validate()
        {
            AddBrokenRule(new BusinessRule("TestProp", "For Tests Causes"));
        }

    }
}
