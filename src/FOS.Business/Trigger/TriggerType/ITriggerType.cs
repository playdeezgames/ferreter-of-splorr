namespace FOS.Business
{
    internal interface ITriggerType
    {
        string Identifier { get; }
        void Fire(ITrigger trigger, ICharacter character);
    }
}