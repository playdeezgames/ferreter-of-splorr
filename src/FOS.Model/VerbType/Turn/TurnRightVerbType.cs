using FOS.Business;
using FOS.Model;

namespace FOS.Model
{
    internal class TurnRightVerbType : IVerbType
    {
        public string Identifier => TurnVerbs.TURN_RIGHT;

        public bool CanPerform(ICharacter character)
        {
            return character.HasMode() && character.GetMode() == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Right";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = character.Grimoire.GetNextDirection(character.Direction);
            character.ClearMode();
            character.AddMessage(Moods.NORMAL, "You turn right.");
        }
    }
}