using FOS.Data;

namespace FOS.Business
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    internal abstract class InventoryEntity<TEntityData>(WorldData data, IGrimoire grimoire) : Entity<TEntityData>(data, grimoire), IInventoryEntity where TEntityData : InventoryEntityData
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    {
        public IInventory Inventory
        {
            get
            {
                if (!GetEntityData().InventoryId.HasValue)
                {
                    GetEntityData().InventoryId = World.CreateInventory().InventoryId;
                }
                return new Inventory(data, grimoire, GetEntityData().InventoryId!.Value);
            }
        }
    }
}
