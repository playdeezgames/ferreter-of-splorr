using FOS.Data;

namespace FOS.Business
{
    internal class Location(WorldData data, Guid locationId) : Entity<LocationData>(data), ILocation
    {
        public Guid LocationId => locationId;

        public string Name => GetEntityData().Name;

        public IEnumerable<IRoute> Routes => GetEntityData().RouteIds.Select(x => new Route(_data, x.Key, x.Value));

        public IEnumerable<IFeature> Features => GetEntityData().FeatureIds.Select(x => new Feature(_data, x));

        public bool HasFeatures => GetEntityData().FeatureIds.Count != 0;

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
            return _data.Locations[LocationId];
        }

        public void AddFeature(IFeature feature)
        {
            GetEntityData().FeatureIds.Add(feature.FeatureId);
        }
    }
}
