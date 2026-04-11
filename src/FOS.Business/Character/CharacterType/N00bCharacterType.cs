namespace FOS.Business
{
    internal class N00bCharacterType : ICharacterType
    {
        public string Identifier => CharacterTypes.N00B;

        public void Initialize(ICharacter character)
        {
        }

        public void AddMessage(ICharacter character, string mood, string text)
        {
            character.World.AddMessage(mood, text);
        }
    }
}
