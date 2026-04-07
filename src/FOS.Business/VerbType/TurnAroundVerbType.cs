namespace FOS.Business
{
    internal class TurnAroundVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_AROUND;

        public bool CanPerform(ICharacter character)
        {
            return true;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Around";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Direction.GetOppositeDirection();
        }
    }
}