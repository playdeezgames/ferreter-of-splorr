namespace FOS.Business
{
    internal class TurnLeftVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_LEFT;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Left";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Direction.GetPreviousDirection();
            character.ClearMetadata(Metadatas.MODE);
            character.AddMessage(Moods.NORMAL, "You turn left.");
        }
    }
}
