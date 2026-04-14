using FOS.Data;

namespace FOS.Business
{
    internal abstract class InventoryEntity<TEntityData>(
        WorldData data,
        IGrimoire grimoire) :
            Entity<TEntityData>(
                data,
                grimoire),
            IInventoryEntity where TEntityData : InventoryEntityData
    {
        protected abstract InventoryType InventoryType { get; }
        protected abstract Guid InventoryParentId { get; }
        public IInventory Inventory
        {
            get
            {
                if (!GetEntityData().InventoryId.HasValue)
                {
                    GetEntityData().InventoryId = World.CreateInventory(InventoryType, InventoryParentId).InventoryId;
                }
                return new Inventory(Data, Grimoire, GetEntityData().InventoryId!.Value);
            }
        }

        public abstract bool InterceptItem(IItem item);
    }
}
