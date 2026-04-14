using FOS.Business;

namespace FOS.Model
{
    internal class GorachanIntroductionVerbType : IVerbType
    {
        public string Identifier => GorachanVerbs.GORACHAN_INTRODUCTION;

        public bool CanPerform(ICharacter character)
        {
            return
                character.IsInMode(Modes.CHARACTERS) &&
                (character.FocusCharacter?.HasTag(Tags.GORACHAN) ?? false);
        }

        public string GetText(ICharacter character)
        {
            return "\"Hello!\"";
        }

        public void Perform(ICharacter character)
        {
            character.AddMessage(Moods.NORMAL, "Gorachan says, \"Henlo!\".");
        }
    }
}