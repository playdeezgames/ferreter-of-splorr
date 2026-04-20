using FOS.Business;

namespace FOS.Model
{
    internal interface IVerbType
    {
        string Identifier { get; }
        bool CanPerform(ICharacter character, params string[] parameters);
        string GetText(ICharacter character);
        void Perform(ICharacter character, params string[] parameters);
    }
}
