using FOS.Business;

namespace FOS.Model
{
    internal class TurnAroundVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_AROUND;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Around";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Grimoire.GetOppositeDirection(character.Direction);
            character.ClearMetadata(Metadatas.MODE);
            character.AddMessage(Moods.NORMAL, "You turn around.");
        }
    }
}