namespace FOS.Business
{
    public interface ITrigger : IEntity
    {
        Guid TriggerId { get; }
        void Fire(ICharacter character);
        ITrigger? NextTrigger { get; set; }
    }
}
