using FOS.Business;

namespace FOS.Model
{
    internal class MoveModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.MOVE_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.IsDead() && !character.HasMode();
        }

        public string GetText(ICharacter character)
        {
            return "Move...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMode(Modes.MOVE);
        }
    }
}