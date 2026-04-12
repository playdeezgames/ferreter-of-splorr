using FOS.Data;
using System.Data;

namespace FOS.Business
{
    public class World(WorldData data, IGrimoire grimoire) : IWorld
    {
        public ICharacter? Avatar
        {
            get
            {
                return (data.AvatarCharacterId.HasValue) ? (new Character(data, grimoire, data.AvatarCharacterId.Value)) : (null);
            }
            set
            {
                if (value == null)
                {
                    data.AvatarCharacterId = null;
                }
                else
                {
                    data.AvatarCharacterId = value.CharacterId;
                }
            }
        }

        public IEnumerable<IMessage> Messages => Enumerable.Range(0, data.Messages.Count).Select(x => new Message(data, x));

        public void Clear()
        {
            data.AvatarCharacterId = null;
            data.Characters.Clear();
        }

        public ILocation CreateLocation(
            string name,
            Action<ILocation>? initializer = null)
        {
            var locationId = Guid.NewGuid();
            data.Locations[locationId] = new LocationData
            {
                Name = name
            };
            var result = new Location(data, grimoire, locationId);
            initializer?.Invoke(result);
            return result;
        }

        public IRoute CreateRoute(
            string name,
            string direction,
            ILocation fromLocation,
            ILocation toLocation,
            Action<IRoute>? initializer = null)
        {
            var routeId = Guid.NewGuid();
            data.Routes[routeId] = new RouteData
            {
                ToLocationId = toLocation.LocationId,
                Name = name
            };
            var result = new Route(data, grimoire, direction, routeId);
            fromLocation.SetRoute(direction, result);
            initializer?.Invoke(result);
            return result;
        }

        public void Initialize(Action<IWorld> initializer)
        {
            Clear();
            initializer.Invoke(this);
        }

        public IFeature GetFeature(Guid featureId)
        {
            return new Feature(data, grimoire, featureId);
        }

        public IItem CreateItem(
            string itemType,
            string name,
            Action<IItem>? initializer = null)
        {
            var itemId = Guid.NewGuid();
            data.Items[itemId] = new ItemData
            {
                ItemType = itemType,
                Name = name
            };
            var result = new Item(data, grimoire, itemId);
            initializer?.Invoke(result);
            return result;
        }

        public IInventory CreateInventory()
        {
            var inventoryId = Guid.NewGuid();
            data.Inventories[inventoryId] = new InventoryData();
            var result = new Inventory(data, grimoire, inventoryId);
            return result;
        }

        public void ClearMessages()
        {
            data.Messages.Clear();
        }

        public void AddMessage(string mood, string text)
        {
            data.Messages.Add(new MessageData { Mood = mood, Text = text });
        }

        public IItem GetItem(Guid itemId)
        {
            return new Item(data, grimoire, itemId);
        }
    }
}
