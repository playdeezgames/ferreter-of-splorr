using FOS.Business;

namespace FOS.Model
{
    internal class BlurFeatureVerbType : IVerbType
    {
        public string Identifier => FeatureVerbs.BLUR_FEATURE;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && character.HasFocusFeature;
        }

        public string GetText(ICharacter character)
        {
            return "Features...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.FocusFeature = null;
        }
    }
}