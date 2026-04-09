using FOS.Data;
using TGGD.Business;

namespace FOS.Business
{
    internal class Character : Entity<CharacterData>, ICharacter
    {
        private readonly WorldData _data;
        private readonly Guid _characterId;
        private ICharacterType CharacterType => CharacterTypes.All[GetEntityData().CharacterType];

        internal Character(WorldData data, Guid characterId)
        {
            _data = data;
            _characterId = characterId;
        }

        public Guid CharacterId => _characterId;

        public IWorld World => new World(_data);

        Direction ICharacter.Direction
        {
            get => GetEntityData().Direction;
            set => GetEntityData().Direction = value;
        }
        public ILocation Location
        {
            get => new Location(_data, GetEntityData().LocationId);
            set
            {
                Location.RemoveCharacter(this);
                GetEntityData().LocationId = value.LocationId;
                Location.AddCharacter(this);
            }
        }

        public IFeature? Feature
        {
            get
            {
                var featureId = GetEntityData().FeatureId;
                if (featureId.HasValue)
                {
                    return new Feature(_data, featureId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().FeatureId = value?.FeatureId;
            }
        }

        public bool HasFeature => GetEntityData().FeatureId.HasValue;

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

        internal override CharacterData GetEntityData()
        {
            return _data.Characters[_characterId];
        }
    }
}
