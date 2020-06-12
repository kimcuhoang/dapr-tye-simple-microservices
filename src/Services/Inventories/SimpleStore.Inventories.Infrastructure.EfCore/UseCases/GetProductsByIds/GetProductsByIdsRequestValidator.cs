using FluentValidation;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.GetProductsByIds
{
    public class GetProductsByIdsRequestValidator : AbstractValidator<GetProductsByIdsRequest>
    {
        public GetProductsByIdsRequestValidator()
        {
            RuleFor(x => x.ProductIds)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();
        }
    }
}
