using FOS.Business;

namespace FOS.Model
{
    internal class TurnLeftVerbType : IVerbType
    {
        public string Identifier => TurnVerbs.TURN_LEFT;

        public bool CanPerform(ICharacter character)
        {
            return !character.IsDead() && character.HasMode() && character.GetMode() == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Left";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = Directions.All[character.Direction].Previous;
            character.ClearMode();
            character.AddMessage(Moods.NORMAL, "You turn left.");
        }
    }
}
