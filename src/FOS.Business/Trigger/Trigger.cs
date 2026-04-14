using FOS.Data;

namespace FOS.Business
{
    internal class Trigger(
        WorldData data,
        IGrimoire grimoire,
        Guid triggerId) :
            InventoryEntity<TriggerData>(
                data,
                grimoire),
            ITrigger
    {
        public Guid TriggerId => triggerId;

        public ITrigger? NextTrigger
        {
            get
            {
                var nextTriggerId = GetEntityData().NextTriggerId;
                if (nextTriggerId.HasValue)
                {
                    return new Trigger(Data, Grimoire, nextTriggerId.Value);
                }
                return null;
            }
            set
            {
                GetEntityData().NextTriggerId = value?.TriggerId;
            }
        }

        public string TriggerType => GetEntityData().TriggerType;

        protected override InventoryType InventoryType => InventoryType.TRIGGER;

        protected override Guid InventoryParentId => TriggerId;

        public ITrigger AppendTrigger(string triggerType, Action<ITrigger>? initializer = null)
        {
            if (NextTrigger != null)
            {
                return NextTrigger.AppendTrigger(triggerType, initializer);
            }
            else
            {
                var triggerId = Guid.NewGuid();
                Data.Triggers[triggerId] = new TriggerData
                {
                    TriggerType = triggerType
                };
                var result = new Trigger(Data, Grimoire, triggerId);
                initializer?.Invoke(result);
                GetEntityData().NextTriggerId = result.TriggerId;
                return result;
            }
        }

        public void Fire(ICharacter character)
        {
            Grimoire.FireTrigger(this, character);
            NextTrigger?.Fire(character);
        }

        public override bool InterceptItem(IItem item)
        {
            return false;
        }

        internal override TriggerData GetEntityData()
        {
            return Data.Triggers[TriggerId];
        }
    }
}
