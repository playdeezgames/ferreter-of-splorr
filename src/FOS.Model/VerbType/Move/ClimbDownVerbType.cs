using FOS.Business;

namespace FOS.Model
{
    internal class ClimbDownVerbType : IVerbType
    {
        public string Identifier => Verbs.CLIMB_DOWN;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMetadata(Metadatas.MODE) &&
                character.GetMetadata(Metadatas.MODE) == Modes.MOVE &&
                character.Location.HasRoute(Directions.DOWN);
        }

        public string GetText(ICharacter character)
        {
            return "Climb Down";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(Directions.DOWN)!;
            character.AddMessage(Moods.NORMAL, $"You climb down {route.Name}.");
            character.Location = route.Destination;
            character.ClearMetadata(Metadatas.MODE);
        }
    }
}