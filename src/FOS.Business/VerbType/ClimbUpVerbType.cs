namespace FOS.Business
{
    internal class ClimbUpVerbType : IVerbType
    {
        public string Identifier => Verbs.CLIMB_UP;

        public bool CanPerform(ICharacter character)
        {
            return
                character.HasMetadata(Metadatas.MODE) &&
                character.GetMetadata(Metadatas.MODE) == Modes.MOVE &&
                character.Location.HasRoute(Data.Direction.UP);
        }

        public string GetText(ICharacter character)
        {
            return "Climb Up";
        }

        public void Perform(ICharacter character)
        {
            character.Location = character.Location.GetRoute(Data.Direction.UP)!.Destination;
            character.ClearMetadata(Metadatas.MODE);
        }
    }
}