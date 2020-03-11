using System;
using HotChocolate.Types;
using SimpleStore.Domain.Models;
using SimpleStore.ProductCatalog.Domain.Models;
using SimpleStore.ProductCatalog.Infrastructure.EfCore.Dto;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class ProductType : ObjectType<ProductDto>
    {
        #region Overrides of ObjectType<Product>

        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor
                .Field(x => x.ProductId)
                .Type<IdType>();

            descriptor
                .Field(x => x.Name)
                .Type<StringType>();
        }

        #endregion
    }
}
