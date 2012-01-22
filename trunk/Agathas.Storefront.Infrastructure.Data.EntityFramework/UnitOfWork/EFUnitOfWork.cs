using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Agathas.Storefront.Domain.Entities;

namespace Agathas.Storefront.Infrastructure.Data.EntityFramework.UnitOfWork
{
    public class EFUnitOfWork : IQueryableUnitOfWork
    {
        #region Implementation of ISql

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUnitOfWork

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void CommitAndRefreshChanges()
        {
            throw new NotImplementedException();
        }

        public void RollbackChanges()
        {
            throw new NotImplementedException();
        }

        public void RegisterChanges<TEntity>(TEntity item) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IObjectSet<TEntity> CreateSet<TEntity>() where TEntity : class, IObjectWithChangeTracker
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
