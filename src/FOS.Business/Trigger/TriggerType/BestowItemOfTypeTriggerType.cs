namespace FOS.Business
{
    internal class BestowItemOfTypeTriggerType : ITriggerType
    {
        public string Identifier => TriggerTypes.BESTOW_ITEM_OF_TYPE;

        public void Fire(ITrigger trigger, ICharacter character)
        {
            //TODO: bestow. cuz bestowing is what this trigger is ALL ABOUT!
        }

        public void Initialize(ITrigger trigger)
        {
        }
    }
}