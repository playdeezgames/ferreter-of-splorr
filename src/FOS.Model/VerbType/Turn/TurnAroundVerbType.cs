using FOS.Business;

namespace FOS.Model
{
    internal class TurnAroundVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_AROUND;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMode() && character.GetMode() == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Around";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Grimoire.GetOppositeDirection(character.Direction);
            character.ClearMode();
            character.AddMessage(Moods.NORMAL, "You turn around.");
        }
    }
}