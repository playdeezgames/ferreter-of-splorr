using FOS.Data;

namespace FOS.Business
{
    internal abstract class Entity<TEntityData>(WorldData data, IGrimoire grimoire) : IEntity where TEntityData : EntityData
    {
        public IWorld World => new World(data, grimoire);

        protected WorldData Data => data;

        public IGrimoire Grimoire => grimoire;

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
            return GetEntityData().Statistics[statisticTypeId];
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
            GetEntityData().Statistics[statisticTypeId] = statisticValue;
        }

        public void SetTag(string tagId)
        {
            GetEntityData().Tags.Add(tagId);
        }

        internal abstract TEntityData GetEntityData();
    }
}
