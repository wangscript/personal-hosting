using Agathas.Storefront.Domain.MainModule.Contracts;
using Agathas.Storefront.Domain.MainModule.Entities;
using Agathas.Storefront.Infrastructure.CrossCutting.Logging;

namespace Agathas.Storefront.Infrastructure.Data.EntityFramework.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IQueryableUnitOfWork queryableUnitOfWork, ITraceManager traceManager)
            : base(queryableUnitOfWork, traceManager)
        {
        }
    }
}
