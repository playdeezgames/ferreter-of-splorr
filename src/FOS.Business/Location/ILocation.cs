namespace FOS.Business
{
    public interface ILocation : IInventoryEntity
    {
        Guid LocationId { get; }
        void AddCharacter(ICharacter character);
        void RemoveCharacter(ICharacter character);
        void SetRoute(string direction, IRoute result);
        string Name { get; }
        IEnumerable<IRoute> Routes { get; }
        bool HasRoute(string direction);
        IRoute? GetRoute(string direction);
        void AddFeature(IFeature feature);
        IEnumerable<IFeature> Features { get; }
        bool HasFeatures { get; }
        IFeature CreateFeature(
            string name,
            Action<IFeature>? initializer = null);
        ICharacter CreateCharacter(
            string direction,
            Action<ICharacter>? initializer = null);
        IRoute CreateRoute(
            string name,
            string direction,
            ILocation toLocation,
            Action<IRoute>? initializer = null);
    }
}
