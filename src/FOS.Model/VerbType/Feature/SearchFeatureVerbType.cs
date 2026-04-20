using FOS.Business;

namespace FOS.Model
{
    internal class SearchFeatureVerbType : IVerbType
    {
        public string Identifier => FeatureVerbs.SEARCH_FEATURE;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && (character.FocusFeature?.HasTrigger(Triggers.SEARCH) ?? false);
        }

        public string GetText(ICharacter character)
        {
            return "Search...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.FocusFeature!.FireTrigger(Triggers.SEARCH, character);
        }
    }
}