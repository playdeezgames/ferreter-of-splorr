namespace FOS.Business
{
    internal class InventoryModeVerbType : IVerbType
    {
        public string Identifier => Verbs.INVENTORY_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMetadata(Metadatas.MODE) && character.Inventory.HasItems;
        }

        public string GetText(ICharacter character)
        {
            return "Inventory...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMetadata(Metadatas.MODE, Modes.INVENTORY);
        }
    }
}