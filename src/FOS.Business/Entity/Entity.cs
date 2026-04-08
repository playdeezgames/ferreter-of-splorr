using FOS.Data;

namespace FOS.Business
{
    internal abstract class Entity<TEntityData> : IEntity where TEntityData : EntityData
    {
        public int GetStatistic(string statisticTypeId)
        {
            return GetEntityData().Statistics[statisticTypeId];
        }

        public void SetStatistic(string statisticTypeId, int statisticValue)
        {
            GetEntityData().Statistics[statisticTypeId] = statisticValue;
        }

        internal abstract TEntityData GetEntityData();
    }
}
