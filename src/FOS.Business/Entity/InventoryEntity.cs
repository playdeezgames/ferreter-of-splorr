using FOS.Data;

namespace FOS.Business
{
    internal abstract class InventoryEntity<TEntityData>(WorldData data, IGrimoire grimoire) : Entity<TEntityData>(data, grimoire), IInventoryEntity where TEntityData : InventoryEntityData
    {
        public IInventory Inventory
        {
            get
            {
                if (!GetEntityData().InventoryId.HasValue)
                {
                    GetEntityData().InventoryId = World.CreateInventory().InventoryId;
                }
                return new Inventory(Data, Grimoire, GetEntityData().InventoryId!.Value);
            }
        }
    }
}
