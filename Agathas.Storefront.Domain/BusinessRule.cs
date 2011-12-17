namespace Agathas.Storefront.Domain
{
    /// <summary>
    /// Simple business rule class to store a rule and related entity property
    /// </summary>
    public class BusinessRule
    {
        public string Property { get; set; }
        public string Rule { get; set; }

        public BusinessRule(string property, string rule)
        {
            Property = property;
            Rule = rule;
        }
    }
}
