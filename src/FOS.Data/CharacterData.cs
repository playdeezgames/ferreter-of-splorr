namespace FOS.Data
{
    public class CharacterData : EntityData
    {
        public required string CharacterType { get; set; }
        public required Direction Direction { get; set; }
        public required Guid LocationId { get; set; }
    }
}
