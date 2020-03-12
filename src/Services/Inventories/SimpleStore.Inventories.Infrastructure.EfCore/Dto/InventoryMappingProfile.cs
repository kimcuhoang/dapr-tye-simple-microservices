﻿using System;
using AutoMapper;

namespace SimpleStore.Inventories.Infrastructure.EfCore.Dto
{
    public class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            CreateMap<Domain.Models.Inventory, InventoryDto>()
                .ForMember(dest => dest.InventoryId, opt => opt.MapFrom(src => (Guid)src.InventoryId));
        }
    }
}