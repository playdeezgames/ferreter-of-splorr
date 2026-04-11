using FOS.Data;

namespace FOS.Business
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    internal class Character(WorldData data, IGrimoire grimoire, Guid characterId) : InventoryEntity<CharacterData>(data: data, grimoire: grimoire), ICharacter
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    {
        private ICharacterType CharacterType => CharacterTypes.All[GetEntityData().CharacterType];

        public Guid CharacterId => characterId;

        Direction ICharacter.Direction
        {
            get => GetEntityData().Direction;
            set => GetEntityData().Direction = value;
        }
        public ILocation Location
        {
            get => new Location(data, grimoire, GetEntityData().LocationId);
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
                    return new Feature(data, grimoire, featureId.Value);
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
                    return new Item(data, grimoire, itemId.Value);
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
            return data.Characters[CharacterId];
        }

        public void AddMessage(string mood, string text)
        {
            CharacterType.AddMessage(this, mood, text);
        }
    }
}
