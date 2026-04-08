namespace FOS.Data
{
    public class WorldData
    {
        public Dictionary<Guid, CharacterData> Characters { get; set; } = [];
        public Guid? AvatarCharacterId { get; set; }
        public Dictionary<Guid, LocationData> Locations { get; set; } = [];
    }
}
