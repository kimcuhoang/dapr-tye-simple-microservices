using FluentValidation;
using System;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddProductToInventory
{
    public class AddProductToInventoryRequestValidator : AbstractValidator<AddProductToInventoryRequest>
    {
        public AddProductToInventoryRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEqual(Guid.Empty);

            RuleFor(x => x.InventoryId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().NotEqual(Guid.Empty);
        }
    }
}
