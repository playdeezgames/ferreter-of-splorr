using FOS.Business;

namespace FOS.Model
{
    internal class CharactersModeVerbType : IVerbType
    {
        public string Identifier => Verbs.CHARACTERS_MODE;

        public bool CanPerform(ICharacter character)
        {
            return !character.HasMetadata(Metadatas.MODE) && character.Location.HasOtherCharacters(character);
        }

        public string GetText(ICharacter character)
        {
            return "Characters...";
        }

        public void Perform(ICharacter character)
        {
            character.SetMetadata(Metadatas.MODE, Modes.CHARACTERS);
        }
    }
}