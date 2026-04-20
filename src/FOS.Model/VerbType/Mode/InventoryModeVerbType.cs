using FOS.Business;

namespace FOS.Model
{
    internal class InventoryModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.INVENTORY_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.IsDead() && !character.HasMode() && character.Inventory.HasItems;
        }

        public string GetText(ICharacter character)
        {
            return "Inventory...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMode(Modes.INVENTORY);
        }
    }
}