using FOS.Data;

namespace FOS.Business
{
    internal abstract class Entity<TEntityData> : IEntity where TEntityData : EntityData
    {
        public void ClearMetadata(string metadataId)
        {
            GetEntityData().Metadatas.Remove(metadataId);
        }

        public string GetMetadata(string metadataId)
        {
            return GetEntityData().Metadatas[metadataId];
        }

        public int GetStatistic(string statisticTypeId)
        {
            return GetEntityData().Statistics[statisticTypeId];
        }

        public bool HasMetadata(string metadataId)
        {
            return GetEntityData().Metadatas.ContainsKey(metadataId);
        }

        public void SetMetadata(string metadataId, string metadataValue)
        {
            GetEntityData().Metadatas[metadataId] = metadataValue;
        }

        public void SetStatistic(string statisticTypeId, int statisticValue)
        {
            GetEntityData().Statistics[statisticTypeId] = statisticValue;
        }

        internal abstract TEntityData GetEntityData();
    }
}
