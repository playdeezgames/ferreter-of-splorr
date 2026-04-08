using FOS.Data;

namespace FOS.Business
{
    internal class EnterLocationVerbType : IVerbType
    {
        public string Identifier => Verbs.ENTER_LOCATION;

        public bool CanPerform(ICharacter character)
        {
            return character.Location.HasRoute(Direction.IN);
        }

        public string GetText(ICharacter character)
        {
            return "Enter";
        }

        public void Perform(ICharacter character)
        {
            character.Location = character.Location.GetRoute(Direction.IN)!.Destination;
        }
    }
}