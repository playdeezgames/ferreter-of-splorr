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
            data.Items[item.ItemId].InventoryId = inventoryId;
        }

        public IItem CreateItem(string itemType, string name, Action<IItem>? initializer = null)
        {
            var itemId = Guid.NewGuid();
            data.Items[itemId] = new ItemData
            {
                ItemType = itemType,
                Name = name
            };
            var result = new Item(data, grimoire, itemId);
            AddItem(result);
            initializer?.Invoke(result);
            return result;
        }

        public void RemoveItem(IItem item)
        {
            GetEntityData().ItemIds.Remove(item.ItemId);
            data.Items[item.ItemId].InventoryId = null;
        }

        internal InventoryData GetEntityData()
        {
            return data.Inventories[InventoryId];
        }
    }
}
