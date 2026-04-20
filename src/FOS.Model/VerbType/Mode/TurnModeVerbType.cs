using FOS.Business;

namespace FOS.Model
{
    internal class TurnModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.TURN_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.IsDead() && !character.HasMode();
        }

        public string GetText(ICharacter character)
        {
            return "Turn...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMode(Modes.TURN);
        }
    }
}