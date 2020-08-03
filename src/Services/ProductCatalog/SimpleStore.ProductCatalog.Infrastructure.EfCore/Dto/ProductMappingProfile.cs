using System;
using AutoMapper;
using SimpleStore.ProductCatalog.Domain.Models;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
            => CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => (Guid) src.Id));
    }
}
