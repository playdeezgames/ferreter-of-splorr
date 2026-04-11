using FOS.Data;

namespace FOS.Business
{
#pragma warning disable CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    internal class Trigger(WorldData data, IGrimoire grimoire, Guid triggerId) : InventoryEntity<TriggerData>(data, grimoire), ITrigger
#pragma warning restore CS9107 // Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
    {
        public Guid TriggerId => triggerId;

        public ITrigger? NextTrigger
        {
            get
            {
                var nextTriggerId = GetEntityData().NextTriggerId;
                if (nextTriggerId.HasValue)
                {
                    return new Trigger(data, grimoire, nextTriggerId.Value);
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
            return data.Triggers[TriggerId];
        }
    }
}
