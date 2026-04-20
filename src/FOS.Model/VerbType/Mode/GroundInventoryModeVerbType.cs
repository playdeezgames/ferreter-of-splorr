using FOS.Business;

namespace FOS.Model
{
    internal class GroundInventoryModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.GROUND_INVENTORY_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.IsDead() && !character.HasMode() && character.Location.Inventory.HasItems;
        }

        public string GetText(ICharacter character)
        {
            return "Ground...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMode(Modes.GROUND_INVENTORY);
        }
    }
}