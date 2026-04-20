using FOS.Business;

namespace FOS.Model
{
    internal class CharactersModeVerbType : IVerbType
    {
        public string Identifier => ModeVerbs.CHARACTERS_MODE;

        public bool CanPerform(ICharacter character, params string[] parameters)
        {
            return !character.IsDead() && !character.HasMode() && character.Location.HasOtherCharacters(character);
        }

        public string GetText(ICharacter character)
        {
            return "Characters...";
        }

        public void Perform(ICharacter character, params string[] parameters)
        {
            character.SetMode(Modes.CHARACTERS);
        }
    }
}