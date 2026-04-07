namespace FOS.Business
{
    internal class TurnLeftVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_LEFT;

        public bool CanPerform(ICharacter character)
        {
            return true;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Left";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Direction.GetPreviousDirection();
        }
    }
}
