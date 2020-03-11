using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SimpleStore.Infrastructure.EfCore.Persistence
{
    public class PersistenceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly DbContext _dbContext;
        private readonly ILogger<PersistenceBehavior<TRequest, TResponse>> _logger;

        public PersistenceBehavior(DbContext dbContext, ILogger<PersistenceBehavior<TRequest, TResponse>> logger)
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
                var response = await next();
                await this._dbContext.SaveChangesAsync(cancellationToken);
                return response;
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
