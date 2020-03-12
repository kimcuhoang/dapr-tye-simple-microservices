using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using SimpleStore.Inventory.Infrastructure.EfCore.UseCases.GetInventories;

namespace SimpleStore.InventoryApi.GraphQL.ObjectTypes
{
    public class GetInventoriesResponseType : ObjectType<GetInventoriesResponse>
    {
        #region Overrides of ObjectType<GetInventoriesResponse>

        protected override void Configure(IObjectTypeDescriptor<GetInventoriesResponse> descriptor)
        {
            
        }

        #endregion
    }
}
