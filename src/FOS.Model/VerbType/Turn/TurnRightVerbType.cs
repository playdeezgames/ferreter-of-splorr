using FOS.Business;

namespace FOS.Model
{
    internal class TurnRightVerbType : IVerbType
    {
        public string Identifier => TurnVerbs.TURN_RIGHT;

        public bool CanPerform(ICharacter character)
        {
            return !character.IsDead() && character.HasMode() && character.GetMode() == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Right";
        }

        public void Perform(ICharacter character)
        {
            character.Direction = Directions.All[character.Direction].Next;
            character.ClearMode();
            character.AddMessage(Moods.NORMAL, "You turn right.");
        }
    }
}