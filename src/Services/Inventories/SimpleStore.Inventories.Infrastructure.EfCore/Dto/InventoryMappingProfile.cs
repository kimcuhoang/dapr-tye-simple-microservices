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
        }
    }
}
