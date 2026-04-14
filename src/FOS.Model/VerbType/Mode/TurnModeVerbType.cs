using FOS.Business;

namespace FOS.Model
{
    internal class TurnModeVerbType : IVerbType
    {
        public string Identifier => Verbs.TURN_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMode();
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