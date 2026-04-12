using FOS.Data;

namespace FOS.Business
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    internal class Location(WorldData data, IGrimoire grimoire, Guid locationId) : InventoryEntity<LocationData>(data, grimoire), ILocation
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    {
        public Guid LocationId => locationId;

        public string Name => GetEntityData().Name;

        public IEnumerable<IRoute> Routes => GetEntityData().RouteIds.Select(x => new Route(data, grimoire, x.Key, x.Value));

        public IEnumerable<IFeature> Features => GetEntityData().FeatureIds.Select(x => new Feature(data, grimoire, x));

        public bool HasFeatures => GetEntityData().FeatureIds.Count != 0;

        public void AddCharacter(ICharacter character)
        {
            GetEntityData().CharacterIds.Add(character.CharacterId);
        }

        public void SetRoute(string direction, IRoute result)
        {
            GetEntityData().RouteIds[direction] = result.RouteId;
        }

        public void RemoveCharacter(ICharacter character)
        {
            GetEntityData().CharacterIds.Remove(character.CharacterId);
        }

        public bool HasRoute(string direction)
        {
            return GetEntityData().RouteIds.ContainsKey(direction);
        }

        public IRoute? GetRoute(string direction)
        {
            if (!HasRoute(direction))
            {
                return null;
            }
            return new Route(data, grimoire, direction, GetEntityData().RouteIds[direction]);
        }

        internal override LocationData GetEntityData()
        {
            return data.Locations[LocationId];
        }

        public void AddFeature(IFeature feature)
        {
            GetEntityData().FeatureIds.Add(feature.FeatureId);
        }
    }
}
