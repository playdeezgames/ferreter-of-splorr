using FOS.Business;

namespace FOS.Model
{
    internal class ExamineFeatureVerbType : IVerbType
    {
        public string Identifier => VerbTypes.EXAMINE_FEATURE;

        public bool CanPerform(ICharacter character)
        {
            return character.FocusFeature?.HasTrigger(Triggers.EXAMINE) ?? false;
        }

        public string GetText(ICharacter character)
        {
            return "Examine...";
        }

        public void Perform(ICharacter character)
        {
            character.FocusFeature!.FireTrigger(Triggers.EXAMINE, character);
        }
    }
}