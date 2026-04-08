namespace FOS.Business
{
    internal class CancelModeVerbType : IVerbType
    {
        public string Identifier => Verbs.CANCEL_MODE;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) == Modes.TURN;
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