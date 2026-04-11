using FOS.Business;

namespace FOS.Model
{
    internal class MoveAheadVerbType : IVerbType
    {
        public string Identifier => Verbs.MOVE_AHEAD;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMetadata(Metadatas.MODE) &&
                character.GetMetadata(Metadatas.MODE) == Modes.MOVE &&
                character.Location.HasRoute(character.Direction);
        }

        public string GetText(ICharacter character)
        {
            return "Move Ahead";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(character.Direction)!;
            character.AddMessage(Moods.NORMAL, $"You move ahead thru {route.Name}.");
            character.Location = route.Destination;
            character.ClearMetadata(Metadatas.MODE);
        }
    }
}