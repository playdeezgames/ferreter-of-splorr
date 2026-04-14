using FOS.Business;

namespace FOS.Model
{
    internal class ExitLocationVerbType : IVerbType
    {
        public string Identifier => Verbs.EXIT_LOCATION;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMode() &&
                character.GetMode() == Modes.MOVE &&
                character.Location.HasRoute(Directions.OUT);
        }

        public string GetText(ICharacter character)
        {
            return "Exit";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(Directions.OUT)!;
            character.AddMessage(Moods.NORMAL, $"You exit through {route.Name}.");
            character.Location = route.Destination;
            character.ClearMode();
        }
    }
}