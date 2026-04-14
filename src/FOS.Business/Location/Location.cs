using FOS.Data;

namespace FOS.Business
{
    internal class Location(
        WorldData data,
        IGrimoire grimoire,
        Guid locationId) :
            InventoryEntity<LocationData>(
                data,
                grimoire),
            ILocation
    {
        public Guid LocationId => locationId;

        public string Name => GetEntityData().Name;

        public IEnumerable<IRoute> Routes => GetEntityData().RouteIds.Select(x => new Route(Data, Grimoire, x.Key, x.Value));

        public IEnumerable<IFeature> Features => GetEntityData().FeatureIds.Select(x => new Feature(Data, Grimoire, x));

        public bool HasFeatures => GetEntityData().FeatureIds.Count != 0;

        protected override InventoryType InventoryType => InventoryType.LOCATION;

        protected override Guid InventoryParentId => LocationId;

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

        public IFeature CreateFeature(string name, Action<IFeature>? initializer = null)
        {
            var featureId = Guid.NewGuid();
            Data.Features[featureId] = new FeatureData
            {
                Name = name,
                LocationId = LocationId
            };
            var result = new Feature(Data, Grimoire, featureId);
            AddFeature(result);
            initializer?.Invoke(result);
            return result;
        }

        public ICharacter CreateCharacter(string name, string direction, Action<ICharacter>? initializer = null)
        {
            var characterId = Guid.NewGuid();
            Data.Characters[characterId] = new CharacterData
            {
                Name = name,
                Direction = direction,
                LocationId = LocationId
            };
            var result = new Character(Data, Grimoire, characterId);
            AddCharacter(result);
            initializer?.Invoke(result);
            return result;
        }

        public IRoute CreateRoute(
            string name,
            string direction,
            ILocation toLocation,
            Action<IRoute>? initializer = null)
        {
            var routeId = Guid.NewGuid();
            Data.Routes[routeId] = new RouteData
            {
                ToLocationId = toLocation.LocationId,
                Name = name
            };
            var result = new Route(Data, Grimoire, direction, routeId);
            SetRoute(direction, result);
            initializer?.Invoke(result);
            return result;
        }

        public IEnumerable<ICharacter> GetOtherCharacters(ICharacter character)
        {
            return GetEntityData().
                CharacterIds.
                Where(x => x != character.CharacterId).
                Select(x => new Character(Data, Grimoire, x));
        }

        public bool HasOtherCharacters(ICharacter character)
        {
            return GetEntityData().CharacterIds.Any(x => x != character.CharacterId);
        }

        public override bool InterceptItem(IItem item)
        {
            return false;
        }
    }
}
