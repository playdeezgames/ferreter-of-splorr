namespace FOS.Business
{
    internal class TurnModeVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMetadata(Metadatas.MODE);
        }

        public string GetText(ICharacter character)
        {
            return "Turn...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMetadata(Metadatas.MODE, Modes.TURN);
        }
    }
}