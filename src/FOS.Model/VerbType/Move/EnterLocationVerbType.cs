using FOS.Business;

namespace FOS.Model
{
    internal class EnterLocationVerbType : IVerbType
    {
        public string Identifier => Verbs.ENTER_LOCATION;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMode() &&
                character.GetMode() == Modes.MOVE &&
                character.Location.HasRoute(Directions.IN);
        }

        public string GetText(ICharacter character)
        {
            return "Enter";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(Directions.IN)!;
            character.AddMessage(Moods.NORMAL, $"You enter through {route.Name}.");
            character.Location = route.Destination;
            character.ClearMode();
        }
    }
}