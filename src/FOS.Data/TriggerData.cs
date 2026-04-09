namespace FOS.Data
{
    public class TriggerData : EntityData
    {
        public required string TriggerType { get; set; }
        public Guid? NextTriggerId { get; set; }
    }
}