namespace FOS.Business
{
    internal class FeaturesModeVerbType : IVerbType
    {
        public string Identifier => Verbs.FEATURES_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMetadata(Metadatas.MODE) && character.Location.HasFeatures;
        }

        public string GetText(ICharacter character)
        {
            return "Features...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMetadata(Metadatas.MODE, Modes.FEATURES);
        }
    }
}