using System;
using AutoMapper;
using SimpleStore.Inventories.Domain.Models;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            CreateMap<Inventory, InventoryDto>()
                .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => (Guid)src.InventoryId));

            CreateMap<ProductInventory, ProductInventoryDto>()
                .ForMember(dest => dest.ProductInventoryId, opt => opt.MapFrom(src => (Guid)src.ProductInventoryId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => (Guid)src.Product.ProductId))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Product.Code));
        }
    }
}
