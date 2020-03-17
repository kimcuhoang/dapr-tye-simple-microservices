using HotChocolate.Types;
using Microsoft.Extensions.Options;
using SimpleStore.ProductCatalogApi.GraphQL.InputObjects;
using SimpleStore.ProductCatalogApi.GraphQL.Objects;
using SimpleStore.ProductCatalogApi.Options;

namespace SimpleStore.ProductCatalogApi.GraphQL.ObjectTypes
{
    public class MutationType : ObjectType<Mutation>
    {
        private readonly ServiceOptions _serviceOptions;

        public MutationType(IOptions<ServiceOptions> serviceOptions)
            => this._serviceOptions = serviceOptions.Value;

        #region Overrides of ObjectType<Mutation>

        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(x => x.CreateProduct(default))
                .Type<ProductType>()
                .Argument("request", a => a.Type<NonNullType<CreateProductsRequestType>>())
                .Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(Mutation.CreateProduct)}");

            descriptor
                .Field(x => x.UpdateProduct(default))
                .Type<ProductType>()
                .Argument("request", a => a.Type<NonNullType<UpdateProductRequestType>>())
                .Name($"{this._serviceOptions.ProductCatalogApi.ServiceName}_{nameof(Mutation.UpdateProduct)}");
        }

        #endregion
    }
}

/*******************************************************************
//Create product

mutation createProduct($createProductRequest: CreateProductRequest!){
  CreateProduct(request: $createProductRequest){
    productId,
    name
  }
}

// Variables

{
  "createProductRequest":{
    "productName": "Hello Hello"
  }
}

********************************************************************/


/*******************************************************************
//Update product

mutation updateProduct($updateProductRequest: UpdateProductRequest!){
  UpdateProduct(request: $updateProductRequest){
    productId,
    name
  }
}

// Variables

{
  "updateProductRequest": {
    "productId": "724cd96bcc334bfd8291031336f830fe",
    "newProductName": "This is an updated product"
  }
}

********************************************************************/
