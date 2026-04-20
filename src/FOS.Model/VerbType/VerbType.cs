using FOS.Business;

namespace FOS.Model
{
    internal class VerbType(
        string identifier,
        Func<ICharacter, IEnumerable<string>, bool> canPerform,
        Func<ICharacter, string> getText,
        Action<ICharacter, IEnumerable<string>> perform) : IVerbType
    {
        public string Identifier => identifier;

        public bool CanPerform(ICharacter character, params string[] parameters) => canPerform(character, parameters);

        public string GetText(ICharacter character) => getText(character);

        public void Perform(ICharacter character, params string[] parameters) => perform(character, parameters);
    }
}
