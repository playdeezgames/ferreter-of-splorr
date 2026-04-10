namespace FOS.Business
{
    public interface IInventoryEntity : IEntity
    {
        IInventory Inventory { get; }
    }
}
