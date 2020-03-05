using FluentValidation;

namespace SimpleStore.ProductCatalog.Infrastructure.EfCore.UseCases.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull();

            RuleFor(x => x.NewProductName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEmpty();
        }
    }
}
