using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using SimpleStore.Inventory.Infrastructure.EfCore.UseCases.CreateInventory;

namespace SimpleStore.InventoryApi.GraphQL.InputTypes
{
    public class CreateInventoryRequestType : InputObjectType<CreateInventoryRequest>
    {
        #region Overrides of InputObjectType<CreateInventoryRequest>

        protected override void Configure(IInputObjectTypeDescriptor<CreateInventoryRequest> descriptor)
        {
            
        }

        #endregion
    }
}
