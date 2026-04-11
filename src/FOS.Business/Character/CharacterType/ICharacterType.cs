namespace FOS.Business
{
    internal interface ICharacterType
    {
        string Identifier { get; }
        void Initialize(ICharacter character);
        void AddMessage(ICharacter character, string mood, string text);
    }
}
