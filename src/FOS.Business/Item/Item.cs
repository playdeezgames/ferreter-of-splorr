using FOS.Data;

namespace FOS.Business
{
    internal class Item(WorldData data, IGrimoire grimoire, Guid itemId) : Entity<ItemData>(data, grimoire), IItem
    {
        public Guid ItemId => itemId;

        public string Name => GetEntityData().Name;

        internal override ItemData GetEntityData()
        {
            return Data.Items[ItemId];
        }
    }
}
