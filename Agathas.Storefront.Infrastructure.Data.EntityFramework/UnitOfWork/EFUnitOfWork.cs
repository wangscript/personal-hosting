using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using Agathas.Storefront.Domain.Entities;

namespace Agathas.Storefront.Infrastructure.Data.EntityFramework.UnitOfWork
{
    public class EFUnitOfWork : ObjectContext, IQueryableUnitOfWork
    {

        private const string ConnectionString = "name=StorefrontUnitOfWork";
        private const string ContainerName = "StorefrontUnitOfWork";

        #region Constructors

        public EFUnitOfWork()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }

        public EFUnitOfWork(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }

        public EFUnitOfWork(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            ContextOptions.ProxyCreationEnabled = false;
            ContextOptions.LazyLoadingEnabled = false;
            ObjectMaterialized += EfUnitOfWorkObjectMaterialized;
        }

        private void EfUnitOfWorkObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity == null) return;

            bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
            try
            {
                entity.MarkAsUnchanged();
            }
            finally
            {
                entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
            }
            this.StoreReferenceKeyValues(entity);
        }

        #endregion

        #region Implementation of ISql

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return ExecuteStoreQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return ExecuteStoreCommand(sqlCommand, parameters);
        }

        #endregion

        #region Implementation of IDisposable

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion

        #region Implementation of IUnitOfWork

        public void Commit()
        {
            //Default option is DetectChangesBeforeSave
            SaveChanges();

            //accept all changes in STE entities attached in context
            var steEntities = (from entry in
                                   ObjectStateManager.GetObjectStateEntries(~EntityState.Detached)
                               where
                                  entry.Entity != null
                               &&
                                  (entry.Entity as IObjectWithChangeTracker != null)
                               select
                                  entry.Entity as IObjectWithChangeTracker);

            steEntities.ToList().ForEach(ste => ste.MarkAsUnchanged());
        }

        public void CommitAndRefreshChanges()
        {
            try
            {
                Commit();
            }
            catch (OptimisticConcurrencyException ex)
            {

                //if client wins refresh data ( queries database and adapt original values
                //and re-save changes in client
                Refresh(RefreshMode.ClientWins, ex.StateEntries.Select(se => se.Entity));

                SaveChanges();

                //accept all changes in STE entities attached in context
                var steEntities = (from entry in
                                       ObjectStateManager.GetObjectStateEntries(~EntityState.Detached)
                                   where
                                      entry.Entity != null
                                   &&
                                      (entry.Entity as IObjectWithChangeTracker != null)
                                   select
                                      entry.Entity as IObjectWithChangeTracker);

                steEntities.ToList().ForEach(ste => ste.MarkAsUnchanged());
            }
        }

        public void RollbackChanges()
        {
            IEnumerable<object> itemsToRefresh = ObjectStateManager.GetObjectStateEntries(EntityState.Modified)
                                                                        .Where(ose => !ose.IsRelationship && ose.Entity != null)
                                                                        .Select(ose => ose.Entity);
            Refresh(RefreshMode.StoreWins, itemsToRefresh);
        }

        public void RegisterChanges<TEntity>(TEntity item) where TEntity : class,IObjectWithChangeTracker
        {
            CreateObjectSet<TEntity>().ApplyChanges(item);
        }

        public IObjectSet<TEntity> CreateSet<TEntity>() where TEntity : class, IObjectWithChangeTracker
        {
            return CreateObjectSet<TEntity>();
        }

        #endregion
    }
}
