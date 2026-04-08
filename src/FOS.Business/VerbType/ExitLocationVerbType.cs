using FOS.Data;

namespace FOS.Business
{
    internal class ExitLocationVerbType : IVerbType
    {
        public string Identifier => Verbs.EXIT_LOCATION;

        public bool CanPerform(ICharacter character)
        {
            return character.Location.HasRoute(Direction.OUT);
        }

        public string GetText(ICharacter character)
        {
            return "Exit";
        }

        public void Perform(ICharacter character)
        {
            character.Location = character.Location.GetRoute(Direction.OUT)!.Destination;
        }
    }
}