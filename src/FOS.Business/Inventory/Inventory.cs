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
            if (!InventoryParent.InterceptItem(item))
            {
                GetEntityData().ItemIds.Add(item.ItemId);
                data.Items[item.ItemId].InventoryId = inventoryId;
            }
            else
            {
                item.Destroy();
            }
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

        public void Destroy()
        {
            foreach (var item in Items)
            {
                item.Destroy();
            }
            data.Inventories.Remove(inventoryId);
        }

        private World World => new(data, grimoire);

        private IInventoryEntity InventoryParent
        {
            get
            {
                return GetEntityData().InventoryType switch
                {
                    InventoryType.CHARACTER => World.GetCharacter(GetEntityData().ParentId),
                    InventoryType.LOCATION => World.GetLocation(GetEntityData().ParentId),
                    InventoryType.TRIGGER => World.GetTrigger(GetEntityData().ParentId),
                    _ => throw new NotImplementedException()
                };
            }
        }
    }
}
