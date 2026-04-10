using FOS.Data;

namespace FOS.Business
{
    internal class Trigger(WorldData data, Guid triggerId) : InventoryEntity<TriggerData>(data), ITrigger
    {
        public Guid TriggerId => triggerId;

        public ITrigger? NextTrigger
        {
            get
            {
                var nextTriggerId = GetEntityData().NextTriggerId;
                if (nextTriggerId.HasValue)
                {
                    return new Trigger(_data, nextTriggerId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().NextTriggerId = value?.TriggerId;
            }
        }

        public void Fire(ICharacter character)
        {
            TriggerTypes.All[GetEntityData().TriggerType].Fire(this, character);
            NextTrigger?.Fire(character);
        }

        internal override TriggerData GetEntityData()
        {
            return _data.Triggers[TriggerId];
        }
    }
}
