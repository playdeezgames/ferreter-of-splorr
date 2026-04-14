using FOS.Business;

namespace FOS.Model
{
    internal class MoveModeVerbType : IVerbType
    {
        public string Identifier => Verbs.MOVE_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMode();
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