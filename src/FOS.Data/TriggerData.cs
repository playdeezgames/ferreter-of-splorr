namespace FOS.Data
{
    public class TriggerData : InventoryEntityData
    {
        public required string TriggerType { get; set; }
        public Guid? NextTriggerId { get; set; }
    }
}