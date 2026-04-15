namespace FOS.Business
{
    public interface IFeature : IEntity, ITriggerHost
    {
        Guid FeatureId { get; }
        string Name { get; }
    }
}
