using FOS.Data;

namespace FOS.Business
{
    internal abstract class Entity<TEntityData>(WorldData data, IGrimoire grimoire) : IEntity where TEntityData : EntityData
    {
        public IWorld World => new World(data, grimoire);

        protected WorldData Data => data;

        public IGrimoire Grimoire =>
            grimoire;

        public void ClearMetadata(string metadataId)
        {
            GetEntityData().Metadatas.Remove(metadataId);
        }

        public void ClearTag(string tagId)
        {
            GetEntityData().Tags.Remove(tagId);
        }

        public string GetMetadata(string metadataId)
        {
            return GetEntityData().Metadatas[metadataId];
        }

        public int GetStatistic(string statisticTypeId)
        {
            return Math.Clamp(
                GetEntityData().Statistics[statisticTypeId],
                GetStatisticMinimum(statisticTypeId),
                GetStatisticMaximum(statisticTypeId));
        }

        public bool HasMetadata(string metadataId)
        {
            return GetEntityData().Metadatas.ContainsKey(metadataId);
        }

        public bool HasTag(string tagId)
        {
            return GetEntityData().Tags.Contains(tagId);
        }

        public void SetMetadata(string metadataId, string metadataValue)
        {
            GetEntityData().Metadatas[metadataId] = metadataValue;
        }

        public void SetStatistic(string statisticTypeId, int statisticValue)
        {
            GetEntityData().Statistics[statisticTypeId] = Math.Clamp(
                statisticValue,
                GetStatisticMinimum(statisticTypeId),
                GetStatisticMaximum(statisticTypeId));
        }

        public void SetTag(string tagId)
        {
            GetEntityData().Tags.Add(tagId);
        }

        internal abstract TEntityData GetEntityData();

        public int ChangeStatistic(string statisticTypeId, int delta)
        {
            SetStatistic(statisticTypeId, GetStatistic(statisticTypeId) + delta);
            return GetStatistic(statisticTypeId);
        }

        public bool HasStatistic(string statisticTypeId)
        {
            return GetEntityData().Statistics.ContainsKey(statisticTypeId);
        }

        public void SetStatisticMaximum(string statisticTypeId, int statisticMaximum)
        {
            GetEntityData().StatisticMaximums[statisticTypeId] = statisticMaximum;
        }

        public void SetStatisticMinimum(string statisticTypeId, int statisticMinimum)
        {
            GetEntityData().StatisticMinimums[statisticTypeId] = statisticMinimum;
        }

        public int GetStatisticMaximum(string statisticTypeId)
        {
            if (GetEntityData().StatisticMaximums.TryGetValue(statisticTypeId, out var statisticMaximum))
            {
                return statisticMaximum;
            }
            return int.MaxValue;
        }

        public int GetStatisticMinimum(string statisticTypeId)
        {
            if (GetEntityData().StatisticMinimums.TryGetValue(statisticTypeId, out var statisticMinimum))
            {
                return statisticMinimum;
            }
            return int.MinValue;
        }
    }
}
