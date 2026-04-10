namespace FOS.Business
{
    public interface ITrigger : IInventoryEntity
    {
        Guid TriggerId { get; }
        void Fire(ICharacter character);
        ITrigger? NextTrigger { get; set; }
    }
}
