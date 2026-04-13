namespace FOS.Business
{
    public interface IInventory
    {
        Guid InventoryId { get; }
        IEnumerable<IItem> Items { get; }
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        bool HasItems { get; }
        IItem CreateItem(
            string itemType,
            string name,
            Action<IItem>? initializer = null);
    }
}
