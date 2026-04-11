using FOS.Business;

namespace FOS.Model
{
    internal interface ITriggerType
    {
        string Identifier { get; }
        void Fire(ITrigger trigger, ICharacter character);
    }
}