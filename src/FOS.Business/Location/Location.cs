using FOS.Data;

namespace FOS.Business
{
    internal class Location: ILocation
    {
        private readonly WorldData _data;
        private readonly Guid _locationId;
        private LocationData LocationData => _data.Locations[_locationId];
        private ILocationType LocationType => LocationTypes.All[LocationData.LocationType];

        public Guid LocationId => _locationId;

        internal Location(WorldData data, Guid locationId)
        {
            _data = data;
            _locationId = locationId;
        }

        public void AddCharacter(ICharacter character)
        {
            LocationData.CharacterIds.Add(character.CharacterId);
        }
    }
}
