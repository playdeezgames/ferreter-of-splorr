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

        public ICharacter CreateCharacter(string characterType, ILocation location)
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
            return result;
        }

        public ILocation CreateLocation(string locationType, string name)
        {
            var locationId = Guid.NewGuid();
            _data.Locations[locationId] = new LocationData
            {
                LocationType = locationType,
                Name = name
            };
            var result = new Location(_data, locationId);
            LocationTypes.All[locationType].Initialize(result);
            return result;
        }

        public IRoute CreateRoute(string routeType, string name, Direction direction, ILocation fromLocation, ILocation toLocation)
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

        public void Initialize()
        {
            Clear();
            var blueRoom = CreateBlueRoom();
            var town = CreateTown();
            var blueRoomTownLocation = RNG.FromEnumerable(town.Where(x => !x.HasRoute(Direction.IN)));
            town.Remove(blueRoomTownLocation);
            CreateRoute(RouteTypes.DOOR, "The Blue Room Entrance", Direction.IN, blueRoomTownLocation, blueRoom);
            CreateRoute(RouteTypes.DOOR, "The Blue Room Exit", Direction.OUT, blueRoom, blueRoomTownLocation);
        }

        private List<ILocation> CreateTown()
        {
            const int TOWN_COLUMNS = 3;
            const int TOWN_ROWS = 3;
            var result = new List<ILocation>();
            foreach (var column in Enumerable.Range(0, TOWN_COLUMNS))
            {
                foreach (var row in Enumerable.Range(0, TOWN_ROWS))
                {
                    var townLocation = CreateLocation(LocationTypes.TOWN, $"Town Location ({column},{row})");
                    townLocation.SetStatistic(StatisticTypes.COLUMN, column);
                    townLocation.SetStatistic(StatisticTypes.ROW, row);
                    result.Add(townLocation);
                }
            }
            foreach (var townLocation in result)
            {
                var column = townLocation.GetStatistic(StatisticTypes.COLUMN);
                var row = townLocation.GetStatistic(StatisticTypes.ROW);
                foreach (var direction in Directions.Cardinal)
                {
                    var nextColumn = direction.GetNextColumn(column);
                    var nextRow = direction.GetNextRow(row);
                    if (nextColumn >= 0 && nextRow >= 0 && nextColumn < TOWN_COLUMNS && nextRow < TOWN_ROWS)
                    {
                        var nextTownLocation =
                            result.Single(x =>
                                x.GetStatistic(StatisticTypes.COLUMN) == nextColumn &&
                                x.GetStatistic(StatisticTypes.ROW) == nextRow);
                        CreateRoute(
                            RouteTypes.ROAD,
                            $"Road to {nextTownLocation.Name}",
                            direction,
                            townLocation,
                            nextTownLocation);
                    }
                }
            }
            return result;
        }

        private ILocation CreateBlueRoom()
        {
            var blueRoom = CreateLocation(LocationTypes.BLUE_ROOM, "The Blue Room");
            var loft = CreateLocation(LocationTypes.LOFT, "The Loft");
            CreateRoute(RouteTypes.LADDER, "Ladder to Loft", Direction.UP, blueRoom, loft);
            CreateRoute(RouteTypes.LADDER, "Ladder from Loft", Direction.DOWN, loft, blueRoom);
            Avatar = CreateCharacter(CharacterTypes.N00B, blueRoom);
            CreateBlueRoomBed(blueRoom);
            return blueRoom;
        }

        private void CreateBlueRoomBed(ILocation location)
        {
            CreateFeature(FeatureTypes.BED, "Yer Bed", location, f =>
            {
                f.SetTrigger(Triggers.SEARCH, CreateTrigger(
                    TriggerTypes.BESTOW_INVENTORY,
                    bit =>
                    {
                        bit.Inventory.AddItem(CreateItem(ItemTypes.DAGGER));
                        bit.NextTrigger = CreateTrigger(
                            TriggerTypes.ADD_MESSAGE,
                            mt =>
                            {
                                mt.SetMetadata(Metadatas.MOOD, Moods.NORMAL);
                                mt.SetMetadata(Metadatas.TEXT, "You find a rusty dagger!");
                                mt.NextTrigger = CreateTrigger(
                                    TriggerTypes.DESTROY_FEATURE_TRIGGER,
                                    dt => dt.SetMetadata(Metadatas.TRIGGER_ID, Triggers.SEARCH));
                            });
                    }));
            });
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

        public IItem CreateItem(string itemType)
        {
            var itemId = Guid.NewGuid();
            _data.Items[itemId] = new ItemData
            {
                ItemType = itemType
            };
            var result = new Item(_data, itemId);
            ItemTypes.All[itemType].Initialize(result);
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
    }
}
