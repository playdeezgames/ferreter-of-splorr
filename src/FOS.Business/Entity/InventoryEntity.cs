using FOS.Data;

namespace FOS.Business
{
    internal abstract class InventoryEntity<TEntityData>(WorldData data) : Entity<TEntityData>(data), IInventoryEntity where TEntityData : InventoryEntityData
    {
        public IInventory Inventory
        {
            get
            {
                if (!GetEntityData().InventoryId.HasValue)
                {
                    GetEntityData().InventoryId = World.CreateInventory().InventoryId;
                }
                return new Inventory(_data, GetEntityData().InventoryId!.Value);
            }
        }
    }
}
