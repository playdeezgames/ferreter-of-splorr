using FOS.Data;

namespace FOS.Business
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    internal class Item(WorldData data, IGrimoire grimoire, Guid itemId) : Entity<ItemData>(data, grimoire), IItem
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    {
        public Guid ItemId => itemId;

        public string Name => GetEntityData().Name;

        internal override ItemData GetEntityData()
        {
            return data.Items[ItemId];
        }
    }
}
