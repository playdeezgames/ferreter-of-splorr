using FOS.Business;

namespace FOS.Model
{
    internal interface IVerbType
    {
        string Identifier { get; }
        bool CanPerform(ICharacter character);
        string GetText(ICharacter character);
        void Perform(ICharacter character);
    }
}
