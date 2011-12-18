using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Objects;
using Agathas.Storefront.Domain.Contracts;
using Agathas.Storefront.Domain.Entities;
using Agathas.Storefront.Infrastructure.CrossCutting.Logging;
using System.Globalization;
using Agathas.Storefront.Infrastructure.Data.Extensions;
using System.Linq.Expressions;

namespace Agathas.Storefront.Infrastructure.Data
{
    /// <summary>
    /// Default base class for repostories.
    /// This generic repository 
    /// is a default implementation of <see cref="IRepository{TEntity}"/>
    /// and your specific repositories can inherit from this base class so automatically will get default implementation.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot, IObjectWithChangeTracker
    {

        #region

        private IQueryableUnitOfWork _unitOfWork;
        private readonly ITraceManager _traceManager;

        #endregion

        #region Constructors

        protected Repository(IQueryableUnitOfWork queryableUnitOfWork, ITraceManager traceManager)
        {
            if (queryableUnitOfWork == null)
                throw new ArgumentNullException("queryableUnitOfWork",
                                                Resources.Messages.exception_ContainerCannotBeNull);

            if (traceManager == null)
                throw new ArgumentNullException("traceManager",
                                                Resources.Messages.exception_ContainerCannotBeNull);

            _unitOfWork = queryableUnitOfWork;
            _traceManager = traceManager;

            _traceManager.TraceInfo(string.Format(CultureInfo.InvariantCulture,
                                                  Resources.Messages.trace_ConstructRepository, typeof (TEntity).Name));
        }

        #endregion

        #region IRepository<TEntity> Members

        /// <summary>
        /// Return a unit of work in this repository
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository{TEntity}"/></param>
        public virtual void Add(TEntity item)
        {
            CheckEntity(item);

            if (item.ChangeTracker != null && item.ChangeTracker.State == ObjectState.Added)
            {
                _unitOfWork.RegisterChanges(item);

                Trace(Resources.Messages.trace_AddedItemRepository);
            }
            else
            {
                throw new InvalidOperationException(Resources.Messages.exception_ChangeTrackerIsNullOrStateIsNOK);
            }
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository{TEntity}"/></param>
        public virtual void Remove(TEntity item)
        {
            CheckEntity(item);

            IObjectSet<TEntity> objectSet = CreateSet();

            objectSet.Attach(item);

            objectSet.DeleteObject(item);

            Trace(Resources.Messages.trace_DeletedItemRepository);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository{TEntity}"/></param>
        public virtual void RegisterItem(TEntity item)
        {
            CheckEntity(item);

            CreateSet().Attach(item);

            Trace(Resources.Messages.trace_AttachedItemToRepository);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="item"><see cref="IRepository{TEntity}"/></param>
        public virtual void Modify(TEntity item)
        {
            CheckEntity(item);

            if (item.ChangeTracker != null && ((item.ChangeTracker.State & ObjectState.Deleted) != ObjectState.Deleted))
                item.MarkAsModified();

            _unitOfWork.RegisterChanges(item);

            Trace(Resources.Messages.trace_AppliedChangedItemRepository);
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        public virtual IEnumerable<TEntity> GetAll()
        {
            Trace(Resources.Messages.trace_GetAllRepository);

            return CreateSet().AsEnumerable();
        }


        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <param name="specification"><see cref="IRepository{TEntity}"/></param>
        /// <returns><see cref="IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetBySpec(ISpecification<TEntity> specification)
        {
            if (specification == null)
                throw new ArgumentNullException("specification");

            Trace(Resources.Messages.trace_GetBySpec);

            return CreateSet().Where(specification.SatisfiedBy()).AsEnumerable();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <typeparam name="TS"><see cref="IRepository{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="IRepository{TEntity}"/></param>
        /// <returns><see cref="IRepository{TEntity}"/></returns>
        public IEnumerable<TEntity> GetPagedElements<TS>(int pageIndex, int pageCount,
                                                         Expression<Func<TEntity, TS>>
                                                             orderByExpression, bool ascending)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression",
                                                Resources.Messages.exception_OrderByExpressionCannotBeNull);

            Trace(Resources.Messages.trace_GetPagedElementsRepository);

            return CreateSet().Paginate(orderByExpression, pageIndex, pageCount, ascending);
        }

        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            //checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Resources.Messages.exception_FilterCannotBeNull);

            _traceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                              Resources.Messages.trace_GetFilteredElementsRepository,
                              typeof (TEntity).Name, filter));

            //Create IObjectSet and perform query
            return CreateSet().Where(filter)
                .ToList();
        }

        public IEnumerable<TEntity> GetFilteredElements<TS>(
            Expression<Func<TEntity, bool>> filter, int pageIndex, int pageCount,
            Expression<Func<TEntity, TS>> orderByExpression, bool ascending)
        {
            //Checking query arguments
            if (filter == null)
                throw new ArgumentNullException("filter", Resources.Messages.exception_FilterCannotBeNull);

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression",
                                                Resources.Messages.exception_OrderByExpressionCannotBeNull);

            _traceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                              Resources.Messages.trace_GetFilteredElementsRepository,
                              typeof (TEntity).Name, filter));

            //Create IObjectSet for this type and perform query
            IObjectSet<TEntity> objectSet = CreateSet();

            return (ascending)
                       ? objectSet
                             .Where(filter)
                             .OrderBy(orderByExpression)
                             .ToList()
                       : objectSet
                             .Where(filter)
                             .OrderByDescending(orderByExpression)
                             .ToList();
        }

        /// <summary>
        /// <see cref="IRepository{TEntity}"/>
        /// </summary>
        /// <typeparam name="TS"><see cref="IRepository{TEntity}"/></typeparam>
        /// <param name="pageIndex"><see cref="IRepository{TEntity}"/></param>
        /// <param name="pageCount"><see cref="IRepository{TEntity}"/></param>
        /// <param name="orderByExpression"><see cref="IRepository{TEntity}"/></param>
        /// <param name="specification"><see cref="IRepository{TEntity}"/></param>
        /// <param name="ascending"><see cref="IRepository{TEntity}"/></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetPagedElements<TS>(int pageIndex, int pageCount,
                                                         Expression<Func<TEntity, TS>>
                                                             orderByExpression, ISpecification<TEntity> specification,
                                                         bool ascending)
        {
            if (pageIndex < 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageIndex, "pageIndex");

            if (pageCount <= 0)
                throw new ArgumentException(Resources.Messages.exception_InvalidPageCount, "pageCount");

            if (orderByExpression == null)
                throw new ArgumentNullException("orderByExpression",
                                                Resources.Messages.exception_OrderByExpressionCannotBeNull);

            if (specification == null)
                throw new ArgumentNullException("specification", Resources.Messages.exception_SpecificationIsNull);

            _traceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                              Resources.Messages.trace_GetPagedElementsRepository,
                              typeof (TEntity).Name, pageIndex, pageCount, orderByExpression));

            //Create associated IObjectSet and perform query

            IObjectSet<TEntity> objectSet = CreateSet();

            //this query cannot  use Paginate IQueryable extension method because Linq queries cannot be
            //merged with Object Builder methods. See Entity Framework documentation for more information

            return (ascending)
                       ? objectSet
                             .Where(specification.SatisfiedBy())
                             .OrderBy(orderByExpression)
                             .Skip(pageIndex*pageCount)
                             .Take(pageCount)
                             .ToList()
                       : objectSet
                             .Where(specification.SatisfiedBy())
                             .OrderByDescending(orderByExpression)
                             .Skip(pageIndex*pageCount)
                             .Take(pageCount)
                             .ToList();
        }

        #endregion

        #region Privite Methods

        private IObjectSet<TEntity> CreateSet()
        {
            if (_unitOfWork != null)
            {
                IObjectSet<TEntity> objectSet = _unitOfWork.CreateSet<TEntity>();

                ObjectSet<TEntity> query = objectSet as ObjectSet<TEntity>;

                if (query != null)
                    query.MergeOption = MergeOption.NoTracking;

                return objectSet;
            }

            throw new InvalidOperationException(Resources.Messages.exception_ContainerCannotBeNull);
        }

        private void CheckEntity(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item", Resources.Messages.exception_ItemArgumentIsNull);
        }

        #endregion

        #region Protected Methods

        protected void Trace(string msg)
        {
            _traceManager.TraceInfo(
                string.Format(CultureInfo.InvariantCulture,
                              msg,
                              typeof (TEntity).Name));
        }

        #endregion
    }
}
