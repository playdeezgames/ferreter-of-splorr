using FOS.Business;

namespace FOS.Model
{
    internal class FeaturesModeVerbType : IVerbType
    {
        public string Identifier => VerbTypes.FEATURES_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMode() && character.Location.HasFeatures;
        }

        public string GetText(ICharacter character)
        {
            return "Features...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMode(Modes.FEATURES);
        }
    }
}