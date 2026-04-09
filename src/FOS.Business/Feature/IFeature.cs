namespace FOS.Business
{
    public interface IFeature : IEntity
    {
        Guid FeatureId { get; }
        string Name { get; }
    }
}
