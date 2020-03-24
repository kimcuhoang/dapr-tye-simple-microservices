using SimpleStore.Infrastructure.Common.Options;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Options
{
    public class ServiceOptions
    {
        public ServiceConfig InventoriesApi { get; set; }
        public ServiceConfig ProductCatalogApi { get; set; }
    }
}
