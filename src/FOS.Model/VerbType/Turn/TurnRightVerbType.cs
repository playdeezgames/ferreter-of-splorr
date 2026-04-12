using FOS.Business;

namespace FOS.Model
{
    internal class TurnRightVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_RIGHT;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMetadata(Metadatas.MODE) && character.GetMetadata(Metadatas.MODE) == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Right";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Grimoire.GetNextDirection(character.Direction);
            character.ClearMetadata(Metadatas.MODE);
            character.AddMessage(Moods.NORMAL, "You turn right.");
        }
    }
}