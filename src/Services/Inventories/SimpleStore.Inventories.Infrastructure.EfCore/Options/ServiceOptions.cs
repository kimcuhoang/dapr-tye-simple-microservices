using SimpleStore.Infrastructure.Common.Options;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Options
{
    public class ServiceOptions : CommonServiceOptions
    {
        public ServiceConfig InventoriesApi { get; set; }
    }
}
