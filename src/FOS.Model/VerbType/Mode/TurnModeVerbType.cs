using FOS.Business;

namespace FOS.Model
{
    internal class TurnModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.TURN_MODE;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && !character.HasMode();
        }

        public string GetText(ICharacter character)
        {
            return "Turn...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.SetMode(Modes.TURN);
        }
    }
}