using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Persistence
{
    public class PersistenceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest, IRequest<TResponse>
    {
        private readonly ProductCatalogDbContext _dbContext;
        private readonly ILogger<PersistenceBehavior<TRequest, TResponse>> _logger;

        public PersistenceBehavior(ProductCatalogDbContext dbContext, ILogger<PersistenceBehavior<TRequest, TResponse>> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        #region Implementation of IPipelineBehavior<in TRequest,TResponse>

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                this._logger.LogInformation($"Commit the transaction for {nameof(request)}.");
                await this._dbContext.SaveChangesAsync(cancellationToken);
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Got the error {ex.Message}.");
                throw;
            }
        }

        #endregion
    }
}
