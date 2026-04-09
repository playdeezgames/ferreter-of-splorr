namespace FOS.Business
{
    public interface IEntity
    {
        void SetStatistic(string statisticTypeId, int statisticValue);
        int GetStatistic(string statisticTypeId);
        bool HasMetadata(string metadataId);
        void SetMetadata(string metadataId, string metadataValue);
        string GetMetadata(string metadataId);
        void ClearMetadata(string metadataId);
        bool HasTag(string tagId);
        void ClearTag(string tagId);
        void SetTag(string tagId);
    }
}