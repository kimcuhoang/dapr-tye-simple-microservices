using SimpleStore.Infrastructure.Common.Options;

namespace SimpleStore.GraphQLApi.Options
{
    public class ServiceOptions : CommonServiceOptions
    {
        public ServiceConfig GraphQLApi { get; set; }
        public ServiceConfig ProductCatalogApi { get; set; }
        public ServiceConfig InventoriesApi { get; set; }
    }
}
