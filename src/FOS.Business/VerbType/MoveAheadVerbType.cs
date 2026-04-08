namespace FOS.Business
{
    internal class MoveAheadVerbType : IVerbType
    {
        public string Identifier => Verbs.MOVE_AHEAD;

        public bool CanPerform(ICharacter character)
        {
            return character.Location.HasRoute(character.Direction);
        }

        public string GetText(ICharacter character)
        {
            return "Move Ahead";
        }

        public void Perform(ICharacter character)
        {
            character.Location = character.Location.GetRoute(character.Direction)!.Destination;
        }
    }
}