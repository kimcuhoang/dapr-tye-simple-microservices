using System;
using AutoMapper;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductId,
                    arg => arg.MapFrom(src => (Guid) src.Id));

            CreateMap<ProductInventory, InventoryProductDto>()
                .ForMember(dest => dest.InventoryId, arg => arg.MapFrom(src => (Guid)src.Inventory.Id))
                .ForMember(dest => dest.Name, arg => arg.MapFrom(src => src.Inventory.Name))
                .ForMember(dest => dest.Location, arg => arg.MapFrom(src => src.Inventory.Location));
        }
    }
}
