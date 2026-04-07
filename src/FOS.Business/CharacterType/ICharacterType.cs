using TGGD.Business;

namespace FOS.Business
{
    internal interface ICharacterType
    {
        string Identifier { get; }
        void Initialize(ICharacter character);
        IEnumerable<IDialogLine> GetLines(ICharacter character);
        IEnumerable<IDialogChoice> GetChoices(ICharacter character);
        void HandleCommand(ICharacter character, string command);
    }
}
