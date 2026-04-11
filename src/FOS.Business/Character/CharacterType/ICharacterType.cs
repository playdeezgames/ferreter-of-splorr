namespace FOS.Business
{
    public interface ICharacterType
    {
        string Identifier { get; }
        void AddMessage(ICharacter character, string mood, string text);
    }
}
