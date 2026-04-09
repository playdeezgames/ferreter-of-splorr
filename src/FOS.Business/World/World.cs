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
            var bed = CreateFeature(FeatureTypes.BED, "Yer Bed", blueRoom);
            bed.SetTag(Tags.SEARCHABLE);
            return blueRoom;
        }

        public IFeature CreateFeature(string featureType, string name, ILocation location)
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
            return result;
        }

        public IFeature GetFeature(Guid featureId)
        {
            return new Feature(_data, featureId);
        }
    }
}
