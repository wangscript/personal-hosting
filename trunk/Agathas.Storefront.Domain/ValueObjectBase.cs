using System.Collections.Generic;
using System.Text;
using Agathas.Storefront.Domain.Exceptions;

namespace Agathas.Storefront.Domain
{
    public abstract class ValueObjectBase
    {
        private readonly List<BusinessRule> _businessRules;

        protected ValueObjectBase()
        {
            _businessRules = new List<BusinessRule>();
            
        }

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _businessRules.Clear();
            Validate();

            if (_businessRules.Count > 0)
            {
                var issues = new StringBuilder();
                _businessRules.ForEach(rule => issues.AppendLine(rule.Rule));

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _businessRules.Add(businessRule);
        }
    }
}
