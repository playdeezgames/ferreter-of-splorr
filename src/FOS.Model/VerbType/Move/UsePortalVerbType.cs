using FOS.Business;

namespace FOS.Model
{
    internal class UsePortalVerbType : IVerbType
    {
        public string Identifier => Verbs.USE_PORTAL;

        public bool CanPerform(ICharacter character)
        {
            return
                character.IsInMode(Modes.MOVE) &&
                character.Location.HasRoute(Directions.PORTAL);
        }

        public string GetText(ICharacter character)
        {
            return "Use Portal";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(Directions.PORTAL)!;
            character.AddMessage(Moods.NORMAL, $"You enter {route.Name}.");
            character.Location = route.Destination;
            character.ClearMode();
        }
    }
}