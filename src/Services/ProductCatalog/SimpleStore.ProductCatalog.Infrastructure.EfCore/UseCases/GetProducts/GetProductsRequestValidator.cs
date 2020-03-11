using FluentValidation;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.GetProducts
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
    {
        public GetProductsRequestValidator()
        {
            RuleFor(x => x.PageIndex)
                .GreaterThan(0);
            RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
