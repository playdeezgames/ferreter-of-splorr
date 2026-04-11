namespace FOS.Business
{
    internal class CancelModeVerbType : IVerbType
    {
        public string Identifier => Verbs.CANCEL_MODE;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMetadata(Metadatas.MODE) &&
                (
                    character.GetMetadata(Metadatas.MODE) == Modes.TURN ||
                    (character.GetMetadata(Metadatas.MODE) == Modes.GROUND_INVENTORY && !character.HasFocusItem) ||
                    (character.GetMetadata(Metadatas.MODE) == Modes.INVENTORY && !character.HasFocusItem) ||
                    character.GetMetadata(Metadatas.MODE) == Modes.MOVE ||
                    (character.GetMetadata(Metadatas.MODE) == Modes.FEATURES && !character.HasFocusFeature));
        }
        public string GetText(ICharacter character)
        {
            return "Cancel";
        }

        public void Perform(ICharacter character)
        {
            character.ClearMetadata(Metadatas.MODE);
        }
    }
}