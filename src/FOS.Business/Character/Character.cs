using FOS.Data;

namespace FOS.Business
{
    internal class Character : InventoryEntity<CharacterData>, ICharacter
    {
        private readonly Guid _characterId;
        private ICharacterType CharacterType => CharacterTypes.All[GetEntityData().CharacterType];

        internal Character(WorldData data, Guid characterId) : base(data)
        {
            _characterId = characterId;
        }

        public Guid CharacterId => _characterId;

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

        public IFeature? FocusFeature
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

        public bool HasFocusFeature => GetEntityData().FeatureId.HasValue;

        public IItem? FocusItem
        {
            get
            {
                var itemId = GetEntityData().ItemId;
                if (itemId.HasValue)
                {
                    return new Item(_data, itemId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().ItemId = value?.ItemId;
            }
        }

        public bool HasFocusItem => GetEntityData().ItemId.HasValue;

        internal override CharacterData GetEntityData()
        {
            return _data.Characters[_characterId];
        }

        public void AddMessage(string mood, string text)
        {
            CharacterType.AddMessage(this, mood, text);
        }
    }
}
