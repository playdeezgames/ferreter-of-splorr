namespace FOS.Business
{
    public interface IFeature : IEntity
    {
        Guid FeatureId { get; }
        string Name { get; }
        void FireTrigger(string triggerCategory, ICharacter character);
        bool HasTrigger(string triggerCategory);
        ITrigger GetTrigger(string triggerCategory);
        void SetTrigger(string triggerCategory, ITrigger trigger);
        void ClearTrigger(string triggerCategory);
    }
}
