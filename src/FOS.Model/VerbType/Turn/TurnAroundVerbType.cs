using FOS.Business;

namespace FOS.Model
{
    internal class TurnAroundVerbType : IVerbType
    {
        public string Identifier => TurnVerbs.TURN_AROUND;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && character.HasMode() && character.GetMode() == Modes.TURN;
        }

        public string GetText(ICharacter character)
        {
            return "Turn Around";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.Direction = Directions.All[character.Direction].Opposite;
            character.ClearMode();
            character.AddMessage(Moods.NORMAL, "You turn around.");
        }
    }
}