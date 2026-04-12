namespace FOS.Business
{
    public interface ITrigger : IInventoryEntity
    {
        Guid TriggerId { get; }
        string TriggerType { get; }
        void Fire(ICharacter character);
        ITrigger? NextTrigger { get; }
        ITrigger AppendTrigger(string triggerType, Action<ITrigger>? initializer = null);
    }
}
