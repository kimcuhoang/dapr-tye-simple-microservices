using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SimpleStore.Infrastructure.EfCore.Persistence
{
    public abstract class ApplicationDbContextBase : DbContext
    {
        protected ApplicationDbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var types = this.CurrentAssembly.DefinedTypes.ToList();

            if (types?.Any() != true) return;

            var customModelBuilderTypes = 
                types.Where(x => x != null && typeof(ICustomModelBuilder).IsAssignableFrom(x) && x != typeof(ICustomModelBuilder));

            foreach (var builderType in customModelBuilderTypes)
            {
                var customModelBuilder = (ICustomModelBuilder)Activator.CreateInstance(builderType);
                customModelBuilder.Build(builder);
            }
        }

        protected abstract Assembly CurrentAssembly { get; }
    }
}
