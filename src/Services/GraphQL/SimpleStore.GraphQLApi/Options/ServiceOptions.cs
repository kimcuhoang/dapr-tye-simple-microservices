using SimpleStore.Infrastructure.Common.Options;

namespace SimpleStore.GraphQLApi.Options
{
    internal class ServiceOptions
    {
        public ServiceConfig GraphQLApi { get; set; }
        public ServiceConfig ProductCatalogApi { get; set; }
    }
}
