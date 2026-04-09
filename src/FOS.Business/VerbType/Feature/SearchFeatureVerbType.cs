namespace FOS.Business
{
    internal class SearchFeatureVerbType : IVerbType
    {
        public string Identifier => Verbs.SEARCH_FEATURE;

        public bool CanPerform(ICharacter character)
        {
            return character.Feature?.HasTag(Tags.SEARCHABLE) ?? false;
        }

        public string GetText(ICharacter character)
        {
            return "Search...";
        }

        public void Perform(ICharacter character)
        {
            character.Feature!.FireTrigger(TriggerTypes.CLEAR_FEATURE_TAG, character);
        }
    }
}