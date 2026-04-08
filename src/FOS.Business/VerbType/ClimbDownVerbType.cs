namespace FOS.Business
{
    internal class ClimbDownVerbType : IVerbType
    {
        public string Identifier => Verbs.CLIMB_DOWN;

        public bool CanPerform(ICharacter character)
        {
            return character.Location.HasRoute(Data.Direction.DOWN);
        }

        public string GetText(ICharacter character)
        {
            return "Climb Down";
        }

        public void Perform(ICharacter character)
        {
            character.Location = character.Location.GetRoute(Data.Direction.DOWN)!.Destination;
        }
    }
}