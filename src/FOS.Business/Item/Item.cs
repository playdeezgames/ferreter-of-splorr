using FOS.Data;

namespace FOS.Business
{
    internal class Item(WorldData data, Guid itemId) : Entity<ItemData>(data), IItem
    {
        public Guid ItemId => itemId;

        public string Name => GetEntityData().Name;

        internal override ItemData GetEntityData()
        {
            return _data.Items[ItemId];
        }
    }
}
