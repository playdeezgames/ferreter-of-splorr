using FOS.Data;

namespace FOS.Business
{
    internal class ExitLocationVerbType : IVerbType
    {
        public string Identifier => Verbs.EXIT_LOCATION;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMetadata(Metadatas.MODE) &&
                character.GetMetadata(Metadatas.MODE) == Modes.MOVE &&
                character.Location.HasRoute(Direction.OUT);
        }

        public string GetText(ICharacter character)
        {
            return "Exit";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(Direction.OUT)!;
            character.AddMessage(Moods.NORMAL, $"You exit through {route.Name}.");
            character.Location = route.Destination;
            character.ClearMetadata(Metadatas.MODE);
        }
    }
}