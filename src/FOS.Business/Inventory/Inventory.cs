using FOS.Data;

namespace FOS.Business
{
    internal class Inventory(WorldData data, IGrimoire grimoire, Guid inventoryId) : IInventory
    {
        public Guid InventoryId => inventoryId;

        public IEnumerable<IItem> Items => GetEntityData().ItemIds.Select(x => new Item(data, grimoire, x));

        public bool HasItems => GetEntityData().ItemIds.Count != 0;

        public void AddItem(IItem item)
        {
            GetEntityData().ItemIds.Add(item.ItemId);
        }

        public void RemoveItem(IItem item)
        {
            GetEntityData().ItemIds.Remove(item.ItemId);
        }

        internal InventoryData GetEntityData()
        {
            return data.Inventories[InventoryId];
        }
    }
}
