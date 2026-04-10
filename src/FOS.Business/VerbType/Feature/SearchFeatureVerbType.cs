namespace FOS.Business
{
    internal class SearchFeatureVerbType : IVerbType
    {
        public string Identifier => Verbs.SEARCH_FEATURE;

        public bool CanPerform(ICharacter character)
        {
            return character.Feature?.HasTrigger(Triggers.SEARCH) ?? false;
        }

        public string GetText(ICharacter character)
        {
            return "Search...";
        }

        public void Perform(ICharacter character)
        {
            character.Feature!.FireTrigger(Triggers.SEARCH, character);
        }
    }
}