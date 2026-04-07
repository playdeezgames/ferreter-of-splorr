namespace FOS.Business
{
    internal class TurnRightVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_RIGHT;

        public bool CanPerform(ICharacter character)
        {
            return true;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Right";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Direction.GetNextDirection();
        }
    }
}