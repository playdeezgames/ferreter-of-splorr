namespace FOS.Business
{
    internal interface IVerbType
    {
        string Identifier { get;  }
        bool CanPerform(ICharacter character);
        string GetText(ICharacter character);
        void Perform(ICharacter character);
    }
}
