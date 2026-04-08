namespace FOS.Business
{
    public interface IFeature
    {
        Guid FeatureId { get; }
        string Name { get; }
    }
}
