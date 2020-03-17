using System;
using FluentValidation;

namespace SimpleStore.Inventories.Infrastructure.EfCore.UseCases.AddOrUpdateProductInventory
{
    public class AddOrUpdateProductInventoryRequestValidator : AbstractValidator<AddOrdUpdateProductInventoryRequest>
    {
        public AddOrUpdateProductInventoryRequestValidator()
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
