using FOS.Data;

namespace FOS.Business
{
    internal class EnterLocationVerbType : IVerbType
    {
        public string Identifier => Verbs.ENTER_LOCATION;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMetadata(Metadatas.MODE) &&
                character.GetMetadata(Metadatas.MODE) == Modes.MOVE &&
                character.Location.HasRoute(Direction.IN);
        }

        public string GetText(ICharacter character)
        {
            return "Enter";
        }

        public void Perform(ICharacter character)
        {
            var route = character.Location.GetRoute(Direction.IN)!;
            character.AddMessage(Moods.NORMAL, $"You enter through {route.Name}.");
            character.Location = route.Destination;
            character.ClearMetadata(Metadatas.MODE);
        }
    }
}