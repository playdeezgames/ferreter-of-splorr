using FOS.Business;
using FOS.Model.VerbType;

namespace FOS.Model
{
    internal class TurnLeftVerbType : IVerbType
    {
        public string Identifier => TurnVerbs.TURN_LEFT;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMode() && character.GetMode() == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Left";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Grimoire.GetPreviousDirection(character.Direction);
            character.ClearMode();
            character.AddMessage(Moods.NORMAL, "You turn left.");
        }
    }
}
