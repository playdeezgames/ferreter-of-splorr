using FOS.Data;
using System.Data;
using TGGD.Business;

namespace FOS.Business
{
    public class World : IWorld
    {
        protected readonly WorldData _data;

        internal World(WorldData worldData)
        {
            _data = worldData;
        }

        public ICharacter? Avatar
        {
            get
            {
                return (_data.AvatarCharacterId.HasValue) ? (new Character(_data, _data.AvatarCharacterId.Value)) : (null);
            }
            set
            {
                if (value == null)
                {
                    _data.AvatarCharacterId = null;
                }
                else
                {
                    _data.AvatarCharacterId = value.CharacterId;
                }
            }
        }

        public string Prompt => Avatar?.Prompt ?? string.Empty;

        public IEnumerable<IMessage> Messages => Enumerable.Range(0, _data.Messages.Count).Select(x => new Message(_data, x));

        public static IWorld Create(WorldData worldData)
        {
            return new World(worldData);
        }

        public void Clear()
        {
            _data.AvatarCharacterId = null;
            _data.Characters.Clear();
        }

        public ICharacter CreateCharacter(string characterType, ILocation location, Action<ICharacter>? initializer = null)
        {
            var characterId = Guid.NewGuid();
            _data.Characters[characterId] = new CharacterData
            {
                CharacterType = characterType,
                Direction = Direction.NORTH,
                LocationId = location.LocationId
            };
            var result = new Character(_data, characterId);
            location.AddCharacter(result);
            CharacterTypes.All[characterType].Initialize(result);
            initializer?.Invoke(result);
            return result;
        }

        public ILocation CreateLocation(
            string locationType,
            string name,
            Action<ILocation>? initializer = null)
        {
            var locationId = Guid.NewGuid();
            _data.Locations[locationId] = new LocationData
            {
                LocationType = locationType,
                Name = name
            };
            var result = new Location(_data, locationId);
            LocationTypes.All[locationType].Initialize(result);
            initializer?.Invoke(result);
            return result;
        }

        public IRoute CreateRoute(
            string routeType,
            string name,
            Direction direction,
            ILocation fromLocation,
            ILocation toLocation,
            Action<IRoute>? initializer = null)
        {
            var routeId = Guid.NewGuid();
            _data.Routes[routeId] = new RouteData
            {
                RouteType = routeType,
                ToLocationId = toLocation.LocationId,
                Name = name
            };
            var result = new Route(_data, direction, routeId);
            fromLocation.SetRoute(direction, result);
            RouteTypes.All[routeType].Initialize(result);
            initializer?.Invoke(result);
            return result;
        }

        public IEnumerable<IDialogChoice> GetChoices()
        {
            return Avatar?.GetChoices() ?? [];
        }

        public IEnumerable<IDialogLine> GetLines()
        {
            return Avatar?.GetLines() ??
                [
                    new DialogLine(Moods.NORMAL,"No avatar!")
                ];
        }

        public void HandleCommand(string command)
        {
            Avatar?.HandleCommand(command);
        }

        public void Initialize(Action<IWorld> initializer)
        {
            Clear();
            initializer.Invoke(this);
        }

        public IFeature CreateFeature(string featureType, string name, ILocation location, Action<IFeature>? initializer = null)
        {
            var featureId = Guid.NewGuid();
            _data.Features[featureId] = new FeatureData
            {
                FeatureType = featureType,
                Name = name,
                LocationId = location.LocationId
            };
            var result = new Feature(_data, featureId);
            location.AddFeature(result);
            FeatureTypes.All[featureType].Initialize(result);
            initializer?.Invoke(result);
            return result;
        }

        public IFeature GetFeature(Guid featureId)
        {
            return new Feature(_data, featureId);
        }

        public ITrigger CreateTrigger(string triggerType, Action<ITrigger>? initializer = null)
        {
            var triggerId = Guid.NewGuid();
            _data.Triggers[triggerId] = new TriggerData
            {
                TriggerType = triggerType
            };
            var result = new Trigger(_data, triggerId);
            TriggerTypes.All[triggerType].Initialize(result);
            initializer?.Invoke(result);
            return result;
        }

        public IItem CreateItem(
            string itemType,
            string name,
            Action<IItem>? initializer = null)
        {
            var itemId = Guid.NewGuid();
            _data.Items[itemId] = new ItemData
            {
                ItemType = itemType,
                Name = name
            };
            var result = new Item(_data, itemId);
            ItemTypes.All[itemType].Initialize(result);
            initializer?.Invoke(result);
            return result;
        }

        public IInventory CreateInventory()
        {
            var inventoryId = Guid.NewGuid();
            _data.Inventories[inventoryId] = new InventoryData();
            var result = new Inventory(_data, inventoryId);
            return result;
        }

        public void ClearMessages()
        {
            _data.Messages.Clear();
        }

        public void AddMessage(string mood, string text)
        {
            _data.Messages.Add(new MessageData { Mood = mood, Text = text });
        }

        public IItem GetItem(Guid itemId)
        {
            return new Item(_data, itemId);
        }
    }
}
