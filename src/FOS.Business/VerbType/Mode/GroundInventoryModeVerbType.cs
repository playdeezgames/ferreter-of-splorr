namespace FOS.Business
{
    internal class GroundInventoryModeVerbType : IVerbType
    {
        public string Identifier => Verbs.GROUND_INVENTORY_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMetadata(Metadatas.MODE) && character.Location.Inventory.HasItems;
        }

        public string GetText(ICharacter character)
        {
            return "Ground...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMetadata(Metadatas.MODE, Modes.GROUND_INVENTORY);
        }
    }
}