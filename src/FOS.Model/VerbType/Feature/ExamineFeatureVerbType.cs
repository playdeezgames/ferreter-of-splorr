using FOS.Business;

namespace FOS.Model
{
    internal class ExamineFeatureVerbType : IVerbType
    {
        public string Identifier => FeatureVerbs.EXAMINE_FEATURE;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && (character.FocusFeature?.HasTrigger(Triggers.EXAMINE) ?? false);
        }

        public string GetText(ICharacter character)
        {
            return "Examine...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.FocusFeature!.FireTrigger(Triggers.EXAMINE, character);
        }
    }
}