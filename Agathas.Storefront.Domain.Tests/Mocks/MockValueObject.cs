namespace Agathas.Storefront.Domain.Tests.Mocks
{
    internal class MockValueObject : ValueObjectBase
    {
        protected override void Validate()
        {
            AddBrokenRule(new BusinessRule("", ""));
        }

        public MockValueObject():base()
        {
            
        }
    }
}
