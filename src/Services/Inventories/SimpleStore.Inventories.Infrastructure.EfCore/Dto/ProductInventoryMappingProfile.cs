using AutoMapper;
using SimpleStore.Inventories.Domain.Models;
using System;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class ProductInventoryMappingProfile : Profile
    {
        public ProductInventoryMappingProfile()
        {
            CreateMap<ProductInventory, ProductInventoryDto>()
                .ForMember(dest => dest.ProductInventoryId, opt => opt.MapFrom(src => (Guid) src.ProductInventoryId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => (Guid) src.Product.ProductId))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Product.Code));
        }
    }
}
