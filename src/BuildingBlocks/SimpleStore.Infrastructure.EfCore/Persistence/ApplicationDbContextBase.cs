using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Domain.Models;

namespace SimpleStore.Infrastructure.EfCore.Persistence
{
    public abstract class ApplicationDbContextBase : DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        protected ApplicationDbContextBase(DbContextOptions dbContextOptions, IDomainEventDispatcher domainEventDispatcher) 
            : base(dbContextOptions)
        {
            this._domainEventDispatcher = domainEventDispatcher;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var types = this.CurrentAssembly.DefinedTypes.ToList();

            if (types?.Any() != true) return;

            var customModelBuilderTypes = 
                types.Where(x => typeof(ICustomModelBuilder).IsAssignableFrom(x) && x != typeof(ICustomModelBuilder));

            foreach (var builderType in customModelBuilderTypes)
            {
                var customModelBuilder = (ICustomModelBuilder)Activator.CreateInstance(builderType);
                customModelBuilder.Build(builder);
            }

            base.OnModelCreating(builder);
        }

        #region Overrides of DbContext

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            DispatchDomainEvents();
            return result;
        }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            DispatchDomainEvents();
            return result;
        }

        #endregion

        protected abstract Assembly CurrentAssembly { get; }

        private void DispatchDomainEvents()
        {
            var entities = ChangeTracker.Entries().Select(e => e.Entity);

            var aggregateRoots = entities.Where(IsAggregateRoot).OfType<IAggregateRoot>();

            foreach (var aggregateRoot in aggregateRoots)
            {
                foreach (var @event in aggregateRoot.UncommittedEvents)
                {
                    this._domainEventDispatcher.Dispatch(@event);
                }

                aggregateRoot.ClearUncommittedEvents();
            }
        }

        private bool IsAggregateRoot(object obj)
        {
            var memberInfo = obj.GetType().BaseType;
            return memberInfo != null && (!memberInfo.IsGenericType && typeof(IAggregateRoot).IsAssignableFrom(memberInfo));
        }
    }
}
