using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    internal class Character : ICharacter
    {
        private readonly WorldData _data;
        private readonly Guid _characterId;
        private CharacterData CharacterData => _data.Characters[_characterId];
        private ICharacterType CharacterType => CharacterTypes.All[CharacterData.CharacterType];

        internal Character(WorldData data, Guid characterId)
        {
            _data = data;
            _characterId = characterId;
        }

        public Guid CharacterId => _characterId;

        public IWorld World => new World(_data);

        Direction ICharacter.Direction { get => CharacterData.Direction; set => CharacterData.Direction = value; }
        public ILocation Location
        {
            get => new Location(_data, CharacterData.LocationId);
            set
            {
                Location.RemoveCharacter(this);
                CharacterData.LocationId = value.LocationId;
                Location.AddCharacter(this);
            }
        }

        public IEnumerable<IDialogChoice> GetChoices()
        {
            return CharacterType.GetChoices(this);
        }

        public IEnumerable<IDialogLine> GetLines()
        {
            return CharacterType.GetLines(this);
        }

        public void HandleCommand(string command)
        {
            CharacterType.HandleCommand(this, command);
        }
    }
}
