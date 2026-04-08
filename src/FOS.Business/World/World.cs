using FOS.Data;
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
            var blueRoom = CreateLocation(LocationTypes.BLUE_ROOM, "The Blue Room");
            var loft = CreateLocation(LocationTypes.LOFT, "The Room That Isn't Blue");
            CreateRoute(RouteTypes.LADDER, "Ladder to Loft", Direction.UP, blueRoom, loft);
            CreateRoute(RouteTypes.LADDER, "Ladder from Loft", Direction.DOWN, loft, blueRoom);
            Avatar = CreateCharacter(CharacterTypes.N00B, blueRoom);
        }
    }
}
