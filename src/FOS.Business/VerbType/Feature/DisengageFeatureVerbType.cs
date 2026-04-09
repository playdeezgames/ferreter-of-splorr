namespace FOS.Business
{
    internal class DisengageFeatureVerbType : IVerbType
    {
        public string Identifier => Verbs.DISENGAGE_FEATURE;

        public bool CanPerform(ICharacter character)
        {
            return character.HasFeature;
        }

        public string GetText(ICharacter character)
        {
            return "Disengage";
        }

        public void Perform(ICharacter character)
        {
            character.Feature = null;
        }
    }
}