using System.Collections.Generic;

namespace Agathas.Storefront.Domain.Entities
{
    /// <summary>
    /// Contain base of logic for validating an entity
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class EntityBase<TId>
    {

        private readonly List<BusinessRule> _rules;


        public virtual TId Id { get; set; }

        protected EntityBase()
        {
            _rules = new List<BusinessRule>();
        }


        protected abstract void Validate();

        protected void AddBrokenRule(BusinessRule rule)
        {
            _rules.Add(rule);
        }

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _rules.Clear();
            Validate();
            return _rules;
        }

        public override bool Equals(object entity)
        {
            return entity != null
                   && entity is EntityBase<TId>
                   && this == (EntityBase<TId>) entity;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1,
                                       EntityBase<TId> entity2)
        {
            if ((object) entity1 == null && (object) entity2 == null)
            {
                return true;
            }
            if ((object) entity1 == null || (object) entity2 == null)
            {
                return false;
            }
            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1,
                                       EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
