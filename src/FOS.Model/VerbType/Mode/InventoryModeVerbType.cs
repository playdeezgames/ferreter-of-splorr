using FOS.Business;

namespace FOS.Model
{
    internal class InventoryModeVerbType : IVerbType
    {
        public string Identifier => Verbs.INVENTORY_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMode() && character.Inventory.HasItems;
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