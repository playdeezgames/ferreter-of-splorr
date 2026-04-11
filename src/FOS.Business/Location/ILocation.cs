using FOS.Data;

namespace FOS.Business
{
    public interface ILocation : IInventoryEntity
    {
        Guid LocationId { get; }
        void AddCharacter(ICharacter character);
        void RemoveCharacter(ICharacter character);
        void SetRoute(Direction direction, IRoute result);
        string Name { get; }
        IEnumerable<IRoute> Routes { get; }
        bool HasRoute(Direction direction);
        IRoute? GetRoute(Direction direction);
        void AddFeature(IFeature feature);
        IEnumerable<IFeature> Features { get; }
        bool HasFeatures { get; }
    }
}
