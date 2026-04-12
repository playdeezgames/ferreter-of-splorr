using FOS.Data;

namespace FOS.Business
{
    internal class Character(WorldData data, IGrimoire grimoire, Guid characterId) : InventoryEntity<CharacterData>(data, grimoire), ICharacter
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
                var featureId = GetEntityData().FeatureId;
                if (featureId.HasValue)
                {
                    return new Feature(Data, Grimoire, featureId.Value);
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
                    return new Item(Data, Grimoire, itemId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().ItemId = value?.ItemId;
            }
        }

        public bool HasFocusItem => GetEntityData().ItemId.HasValue;

        public string Direction
        {
            get => GetEntityData().Direction;
            set => GetEntityData().Direction = value;
        }

        internal override CharacterData GetEntityData()
        {
            return Data.Characters[CharacterId];
        }

        public void AddMessage(string mood, string text)
        {
            Grimoire.AddMessage(this, mood, text);
        }
    }
}
