namespace FOS.Business
{
    public interface IFeature : IEntity
    {
        Guid FeatureId { get; }
        string Name { get; }
        void FireTrigger(string triggerCategory, ICharacter character);
        bool HasTrigger(string triggerCategory);
        ITrigger GetTrigger(string triggerCategory);
        ITrigger AppendTrigger(string triggerCategory, string triggerTypeId, Action<ITrigger>? initializer = null);
        void ClearTrigger(string triggerCategory);
    }
}
