using FOS.Data;

namespace FOS.Business
{
    internal class Character(
        WorldData data,
        IGrimoire grimoire,
        Guid characterId) :
            InventoryEntity<CharacterData>(
                data,
                grimoire),
            ICharacter
    {
        public Guid CharacterId => characterId;

        public ILocation Location
        {
            get => new Location(Data, Grimoire, GetEntityData().LocationId);
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
                var featureId = GetEntityData().FocusFeatureId;
                if (featureId.HasValue)
                {
                    return new Feature(Data, Grimoire, featureId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().FocusFeatureId = value?.FeatureId;
            }
        }

        public bool HasFocusFeature => GetEntityData().FocusFeatureId.HasValue;

        public IItem? FocusItem
        {
            get
            {
                var itemId = GetEntityData().FocusItemId;
                if (itemId.HasValue)
                {
                    return new Item(Data, Grimoire, itemId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().FocusItemId = value?.ItemId;
            }
        }

        public bool HasFocusItem => GetEntityData().FocusItemId.HasValue;

        public string Direction
        {
            get => GetEntityData().Direction;
            set => GetEntityData().Direction = value;
        }

        public string Name => GetEntityData().Name;

        public ICharacter? FocusCharacter
        {
            get
            {
                var characterId = GetEntityData().FocusCharacterId;
                if (characterId.HasValue)
                {
                    return new Character(Data, Grimoire, characterId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().FocusCharacterId = value?.CharacterId;
            }
        }

        public bool HasFocusCharacter => GetEntityData().FocusCharacterId.HasValue;

        protected override InventoryType InventoryType => InventoryType.CHARACTER;

        protected override Guid InventoryParentId => CharacterId;

        internal override CharacterData GetEntityData()
        {
            return Data.Characters[CharacterId];
        }

        public override bool InterceptItem(IItem item)
        {
            return Grimoire.InterceptCharacterItem(this, item);
        }
    }
}
