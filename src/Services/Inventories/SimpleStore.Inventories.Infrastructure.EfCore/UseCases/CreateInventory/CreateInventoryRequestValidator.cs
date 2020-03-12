using FluentValidation;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.CreateInventory
{
    public class CreateInventoryRequestValidator : AbstractValidator<CreateInventoryRequest>
    {
        public CreateInventoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Location)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();
        }
    }
}
