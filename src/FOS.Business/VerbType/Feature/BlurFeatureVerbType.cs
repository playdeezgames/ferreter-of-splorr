namespace FOS.Business
{
    internal class BlurFeatureVerbType : IVerbType
    {
        public string Identifier => Verbs.BLUR_FEATURE;

        public bool CanPerform(ICharacter character)
        {
            return character.HasFocusFeature;
        }

        public string GetText(ICharacter character)
        {
            return "Features...";
        }

        public void Perform(ICharacter character)
        {
            character.FocusFeature = null;
        }
    }
}