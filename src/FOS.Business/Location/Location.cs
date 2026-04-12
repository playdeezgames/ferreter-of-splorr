using FOS.Data;

namespace FOS.Business
{
    internal class Location(WorldData data, IGrimoire grimoire, Guid locationId) : InventoryEntity<LocationData>(data, grimoire), ILocation
    {
        public Guid LocationId => locationId;

        public string Name => GetEntityData().Name;

        public IEnumerable<IRoute> Routes => GetEntityData().RouteIds.Select(x => new Route(Data, Grimoire, x.Key, x.Value));

        public IEnumerable<IFeature> Features => GetEntityData().FeatureIds.Select(x => new Feature(Data, Grimoire, x));

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
            return new Route(Data, Grimoire, direction, GetEntityData().RouteIds[direction]);
        }

        internal override LocationData GetEntityData()
        {
            return Data.Locations[LocationId];
        }

        public void AddFeature(IFeature feature)
        {
            GetEntityData().FeatureIds.Add(feature.FeatureId);
        }
    }
}
