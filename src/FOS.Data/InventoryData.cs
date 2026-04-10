namespace FOS.Data
{
    public class InventoryData : EntityData
    {
        public HashSet<Guid> ItemIds { get; set; } = [];
    }
}
