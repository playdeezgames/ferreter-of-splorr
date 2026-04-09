namespace FOS.Business
{
    public interface IFeature : IEntity
    {
        Guid FeatureId { get; }
        string Name { get; }
        void FireTrigger(string triggerType, ICharacter character);
        bool HasTrigger(string triggerType);
        ITrigger GetTrigger(string triggerType);
        void SetTrigger(string triggerType, ITrigger trigger);
        void ClearTrigger(string triggerType);
    }
}
