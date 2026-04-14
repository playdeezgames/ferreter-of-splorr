namespace FOS.Data
{
    public class InventoryData
    {
        public required Guid ParentId { get; set; }
        public required InventoryType InventoryType { get; set; }
        public HashSet<Guid> ItemIds { get; set; } = [];
    }
}
