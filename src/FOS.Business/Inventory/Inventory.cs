using FOS.Data;

namespace FOS.Business
{
    internal class Inventory(WorldData data, Guid inventoryId) : Entity<InventoryData>(data), IInventory
    {
        public Guid InventoryId => inventoryId;

        public IEnumerable<IItem> Items => GetEntityData().ItemIds.Select(x => new Item(_data, x));

        public void AddItem(IItem item)
        {
            GetEntityData().ItemIds.Add(item.ItemId);
        }

        public void RemoveItem(IItem item)
        {
            GetEntityData().ItemIds.Remove(item.ItemId);
        }

        internal override InventoryData GetEntityData()
        {
            return _data.Inventories[InventoryId];
        }
    }
}
