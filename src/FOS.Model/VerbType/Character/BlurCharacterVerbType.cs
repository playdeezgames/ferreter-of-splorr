using FOS.Business;

namespace FOS.Model
{
    internal class BlurCharacterVerbType : IVerbType
    {
        public string Identifier => VerbTypes.BLUR_CHARACTER;

        public bool CanPerform(ICharacter character) => character.HasFocusCharacter;

        public string GetText(ICharacter character) => "Characters...";

        public void Perform(ICharacter character) => character.FocusCharacter = null;
    }
}