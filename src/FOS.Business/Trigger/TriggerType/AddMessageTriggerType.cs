namespace FOS.Business
{
    internal class AddMessageTriggerType : ITriggerType
    {
        public string Identifier => TriggerTypes.ADD_MESSAGE;

        public void Fire(ITrigger trigger, ICharacter character)
        {
            character.AddMessage(trigger.GetMetadata(Metadatas.MOOD), trigger.GetMetadata(Metadatas.TEXT));
        }

        public void Initialize(ITrigger trigger)
        {
        }
    }
}