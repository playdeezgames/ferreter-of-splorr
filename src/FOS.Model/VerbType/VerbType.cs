using FOS.Business;

namespace FOS.Model
{
    internal class VerbType(
        string identifier,
        Func<ICharacter, bool> canPerform,
        Func<ICharacter, string> getText,
        Action<ICharacter> perform) : IVerbType
    {
        public string Identifier => identifier;

        public bool CanPerform(ICharacter character) => canPerform(character);

        public string GetText(ICharacter character) => getText(character);

        public void Perform(ICharacter character) => perform(character);
    }
}
