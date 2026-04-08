using FOS.Data;

namespace FOS.Business
{
    internal class Location : Entity<LocationData>, ILocation
    {
        private readonly WorldData _data;
        private readonly Guid _locationId;
        private ILocationType LocationType => LocationTypes.All[GetEntityData().LocationType];

        public Guid LocationId => _locationId;

        public string Name => GetEntityData().Name;

        public IEnumerable<IRoute> Routes => GetEntityData().RouteIds.Select(x => new Route(_data, x.Key, x.Value));

        public IEnumerable<IFeature> Features => GetEntityData().FeatureIds.Select(x => new Feature(_data, x));

        internal Location(WorldData data, Guid locationId)
        {
            _data = data;
            _locationId = locationId;
        }

        public void AddCharacter(ICharacter character)
        {
            GetEntityData().CharacterIds.Add(character.CharacterId);
        }

        public void SetRoute(Direction direction, IRoute result)
        {
            GetEntityData().RouteIds[direction] = result.RouteId;
        }

        public void RemoveCharacter(ICharacter character)
        {
            GetEntityData().CharacterIds.Remove(character.CharacterId);
        }

        public bool HasRoute(Direction direction)
        {
            return GetEntityData().RouteIds.ContainsKey(direction);
        }

        public IRoute? GetRoute(Direction direction)
        {
            if (!HasRoute(direction))
            {
                return null;
            }
            return new Route(_data, direction, GetEntityData().RouteIds[direction]);
        }

        internal override LocationData GetEntityData()
        {
            return _data.Locations[_locationId];
        }

        public void AddFeature(IFeature feature)
        {
            GetEntityData().FeatureIds.Add(feature.FeatureId);
        }
    }
}
