using FOS.Data;

namespace FOS.Business
{
    internal class Trigger : Entity<TriggerData>, ITrigger
    {
        private readonly WorldData _data;
        private readonly Guid _triggerId;
        internal Trigger(WorldData data, Guid triggerId)
        {
            _data = data;
            _triggerId = triggerId;
        }

        public Guid TriggerId => _triggerId;

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
            return _data.Triggers[_triggerId];
        }
    }
}
