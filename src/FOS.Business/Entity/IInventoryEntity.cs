namespace FOS.Business
{
    public interface IInventoryEntity : IEntity
    {
        IInventory Inventory { get; }

        bool InterceptItem(IItem item);
    }
}
